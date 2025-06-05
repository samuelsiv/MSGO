using System.Net;
using System.Reflection;
using MSGO.AuthServer;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Types.Interfaces;

foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
             .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>))))
{
    var handler = Activator.CreateInstance(type);
    var packetType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>)).GetGenericArguments()[0];
    typeof(PacketHandlerRegistry).GetMethod(nameof(PacketHandlerRegistry.RegisterHandler))!.MakeGenericMethod(packetType).Invoke(null, [handler]);
    Console.WriteLine($"Registering handler for packet type: {packetType.Name}");
}

AuthServer authServer = new(IPAddress.Any, 50000);
authServer.Start();

while (true)
{
    string? line = Console.ReadLine();
    if (string.IsNullOrEmpty(line)) break;
    if (line != "!") continue;

    Console.Write("Servers restarting...");
    authServer.Restart();
}

Console.Write("Server stopping...");
authServer.Stop();
