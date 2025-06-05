using Arrowgene.Buffers;

namespace MSGO.Core.Utils;

public abstract class BufferProvider
{
    private static readonly StreamBuffer Provider = new();
    public static IBuffer Provide() => Provider.Provide();
    public static IBuffer Provide(byte[] data) => Provider.Provide(data);
}