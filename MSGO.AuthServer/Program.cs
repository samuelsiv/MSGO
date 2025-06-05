using System.Net;
using MSGO.AuthServer;
using MSGO.Core.Packets.Handlers;

PacketHandlerRegistry.RegisterAll();

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
