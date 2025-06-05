using System.Net;
using System.Net.Sockets;
using MSGO.AuthServer;
using NetCoreServer;

namespace MSGO.WorldServer;

class WorldServer : TcpServer
{
    public WorldServer(IPAddress address, int port) : base(address, port) => Console.WriteLine("Starting Auth Server");
    protected override TcpSession CreateSession() => new WorldSession(this);
    protected override void OnError(SocketError error) =>
        Console.WriteLine($"Auth Server caught an error with code {error}");
}