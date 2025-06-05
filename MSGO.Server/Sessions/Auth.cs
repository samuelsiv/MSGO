using MSGO.Server.Packets;
using MSGO.Server.Packets.Handlers;
using MSGO.Server.Types.Network;
using NetCoreServer;
using System.Net.Sockets;

namespace MSGO.Server.Sessions;

public class AuthSession(TcpServer server) : BaseSession(server)
{
    protected override void HandlePacket(BasePacket packet, byte[] rawData) =>
        PacketHandlerRegistry.HandlePacket(this, packet, (PacketRequest)packet.PacketId, rawData);

    protected override void OnError(SocketError error) =>
        Console.WriteLine($"Auth Server session caught an error with code {error}");
}