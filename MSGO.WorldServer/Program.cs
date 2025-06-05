using System.Net;
using System.Reflection;
using MSGO.Core;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Types.Interfaces;
using MSGO.WorldServer;

Logger.Initialize();
Logger.Information("Starting MSGO World Server...");

foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
             .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>))))
{
    var handler = Activator.CreateInstance(type);
    var packetType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>)).GetGenericArguments()[0];
    typeof(PacketHandlerRegistry).GetMethod(nameof(PacketHandlerRegistry.RegisterHandler))!.MakeGenericMethod(packetType).Invoke(null, [handler]);
    Logger.Debug($"Registering handler for packet type: {packetType.Name}");
}

WorldServer authServer = new(IPAddress.Any, 6969);
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