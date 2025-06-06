using MSGO.Core.Packets;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Types.Network;
using NetCoreServer;
using System.Net.Sockets;
using MSGO.Core;
using MSGO.Core.Sessions;

namespace MSGO.AuthServer;

public class WorldSession(TcpServer server) : BaseSession(server)
{
    protected override void HandlePacket(BasePacket packet, byte[] rawData) =>
        PacketHandlerRegistry.HandlePacket(this, packet, (PacketRequest)packet.PacketId, rawData);

    protected override void OnError(SocketError error) =>
        Logger.Error("Battle Server session caught an error with code {Error}", error);
}