using System.Net;
using System.Net.Sockets;
using MSGO.AuthServer;
using MSGO.Core;
using NetCoreServer;

namespace MSGO.WorldServer;

class WorldServer : TcpServer
{
    public WorldServer(IPAddress address, int port) : base(address, port) => 
        Logger.Information("World Server started on {Address}:{Port}", address, port);
    protected override TcpSession CreateSession() => 
        new WorldSession(this);
    protected override void OnError(SocketError error) =>
        Logger.Error("Auth Server caught an error with code {Error}", error);
}