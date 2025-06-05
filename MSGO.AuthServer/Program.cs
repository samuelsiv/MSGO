using System.Net;
using System.Reflection;
using MSGO.AuthServer;
using MSGO.Core;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Types.Interfaces;

Logger.Initialize();
Logger.Information("Starting MSGO Authentication Server...");

foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
             .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>))))
{
    var handler = Activator.CreateInstance(type);
    var packetType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>)).GetGenericArguments()[0];
    typeof(PacketHandlerRegistry).GetMethod(nameof(PacketHandlerRegistry.RegisterHandler))!.MakeGenericMethod(packetType).Invoke(null, [handler]);
    Logger.Debug($"Registering handler for packet type: {packetType.Name}");
}

AuthServer authServer = new(IPAddress.Any, 50000);
authServer.Start();

while (true)
{
    string? line = Console.ReadLine();
    if (string.IsNullOrEmpty(line)) break;
    if (line != "!") continue;

    Logger.Information("Restarting server...");
    authServer.Restart();
}

Logger.Information("Stopping server...");
authServer.Stop();
