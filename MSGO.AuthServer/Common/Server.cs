using System.Net;
using System.Net.Sockets;
using MSGO.AuthServer;
using MSGO.Core;
using NetCoreServer;

namespace MSGO.AuthServer;

sealed class AuthServer : TcpServer
{
    public AuthServer(IPAddress address, int port) : base(address, port)
    {
        Start();
        Logger.Information("Authentication Server started on {Address}:{Port}", address, port);
    }

    protected override TcpSession CreateSession() => new AuthSession(this);
    protected override void OnError(SocketError error) =>
        Logger.Error($"Auth Server caught an error with code {error}");
}