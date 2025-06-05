using MSGO.Core.Packets;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;

namespace MSGO.Core.Types.Interfaces;

public interface IPacketHandler<in TPacket> where TPacket : BasePacket
{
    IEnumerable<PacketRequest> HandledPacketIds { get; }
    void Handle(BaseSession session, TPacket packet);
    bool CanHandle(BaseSession session);
    bool CanHandle(BaseSession session, PacketRequest packetRequest);
}