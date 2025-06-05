using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MSGO.Server.Sessions;

namespace MSGO.Server.Servers;

class AuthServer : TcpServer
{
    public AuthServer(IPAddress address, int port) : base(address, port) => Console.WriteLine("Starting Auth Server");
    protected override TcpSession CreateSession() => new AuthSession(this);
    protected override void OnError(SocketError error) => 
        Console.WriteLine($"Auth Server caught an error with code {error}");
}