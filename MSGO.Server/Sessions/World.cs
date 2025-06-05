using MSGO.Server.Packets;
using MSGO.Server.Packets.Handlers;
using MSGO.Server.Types.Network;
using NetCoreServer;
using System.Net.Sockets;

namespace MSGO.Server.Sessions;

public class WorldSession : BaseSession
{
    public WorldSession(TcpServer server) : base(server) { }
    protected override void HandlePacket(BasePacket packet, byte[] rawData)
    {
        var packetId = (PacketRequest)packet.PacketId;
        PacketHandlerRegistry.HandlePacket(this, packet, packetId, rawData);
        {
            Console.WriteLine($"No handler found for packet {packetId}");
        }
    }

    protected override void OnError(SocketError error) =>
        Console.WriteLine($"Auth Server session caught an error with code {error}");

}