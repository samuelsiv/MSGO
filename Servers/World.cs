using NetCoreServer;
using System.Net.Sockets;
using System.Net;
using MSGO.Server.Sessions;

namespace MSGO.Server.Servers;

class WorldServer : TcpServer
{
    public WorldServer(IPAddress address, int port) : base(address, port) => Console.WriteLine("Starting WorldServer");
    protected override TcpSession CreateSession() { return new WorldSession(this); }
    protected override void OnError(SocketError error) =>
        Console.WriteLine($"World Server caught an error with code {error}");
}