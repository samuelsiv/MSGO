using MSGO.Server.Packets.Handlers;
using MSGO.Server.Packets.Handlers.Auth;
using MSGO.Server.Packets.Handlers.Generic;
using MSGO.Server.Servers;
using System.Net;

//PacketHandlerRegistrar.RegisterAll();

/*
PacketHandlerRegistry.RegisterHandler(new LoginHandler());
PacketHandlerRegistry.RegisterHandler(new VersionCheckHandler());
PacketHandlerRegistry.RegisterHandler(new WorldListHandler());
*/

AuthServer authServer = new(IPAddress.Any, 50000);
WorldServer worldServer = new(IPAddress.Any, 6969);

authServer.Start();
worldServer.Start();

while (true)
{
    string? line = Console.ReadLine();
    if (string.IsNullOrEmpty(line)) break;
    if (line != "!") continue;

    Console.Write("Servers restarting...");
    authServer.Restart();
    worldServer.Restart();
    continue;
}

Console.Write("Server stopping...");
authServer.Stop();
worldServer.Stop();
