using System.Net;
using System.Net.Sockets;
using MSGO.AuthServer;
using MSGO.Core;
using NetCoreServer;

namespace MSGO.BattleServer;

sealed class BattleServer : TcpServer
{
    public BattleServer(IPAddress address, int port) : base(address, port)
    {
        Start();
        Logger.Information("Battle Server started on {Address}:{Port}", address, port);
    }

    protected override TcpSession CreateSession() => 
        new WorldSession(this);
    protected override void OnError(SocketError error) =>
        Logger.Error("Battle Server caught an error with code {Error}", error);
}