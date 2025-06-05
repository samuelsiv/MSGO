using System.Net;
using NetCoreServer;

namespace MSGO.Core;

public class BaseServer<TSession>(IPAddress address, int port) : TcpServer(address, port)
    where TSession : TcpSession, new()
{
    protected override TcpSession CreateSession() => new TSession();
}