using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

[Generator(LanguageNames.CSharp)]
public sealed class Generator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        Debugger.Launch();

        var packetHandlerClasses = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax classDeclaration && classDeclaration.BaseList != null,
                transform: static (syntaxContext, _) =>
                {
                    var classDeclaration = (ClassDeclarationSyntax)syntaxContext.Node;
                    var semanticModel = syntaxContext.SemanticModel;
                    var baseTypes = classDeclaration.BaseList.Types.Select(type => semanticModel.GetTypeInfo(type.Type).Type);
                    return baseTypes.Any(baseType => baseType?.Name == "PacketHandler") ? classDeclaration : null;
                })
            .Where(static classDeclaration => classDeclaration != null);

        // Collect all results into a single list  
        var collectedClasses = packetHandlerClasses.Collect();

        // Register the source output  
        context.RegisterSourceOutput(collectedClasses, static (sourceProductionContext, classes) =>
        {
            var sourceBuilder = new StringBuilder();
            sourceBuilder.AppendLine("// Auto-generated PacketHandler registration");
            sourceBuilder.AppendLine("using System.Collections.Generic;");
            sourceBuilder.AppendLine("namespace GeneratedPacketHandlers");
            sourceBuilder.AppendLine("{");
            sourceBuilder.AppendLine("    public static class PacketHandlerRegistry");
            sourceBuilder.AppendLine("    {");
            sourceBuilder.AppendLine("        public static IReadOnlyList<string> GetPacketHandlers() => new List<string>");
            sourceBuilder.AppendLine("        {");

            foreach (var classDeclaration in classes)
            {
                sourceBuilder.AppendLine($"            \"{classDeclaration.Identifier.Text}\",");
            }

            sourceBuilder.AppendLine("        };");
            sourceBuilder.AppendLine("    }");
            sourceBuilder.AppendLine("}");

            sourceProductionContext.AddSource("PacketHandlerRegistry.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        });
    }
}