using MSGO.Server.Packets;
using MSGO.Server.Sessions;
using MSGO.Server.Types.Network;

namespace MSGO.Server.Types.Interfaces;

public interface IPacketHandler<in TPacket> where TPacket : BasePacket
{
    IEnumerable<PacketRequest> HandledPacketIds { get; }
    void Handle(BaseSession session, TPacket packet);
    bool CanHandle(BaseSession session);
    bool CanHandle(BaseSession session, PacketRequest packetRequest);
}