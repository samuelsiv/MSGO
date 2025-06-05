using MSGO.Core.Packets;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Interfaces;
using MSGO.Core.Types.Network;

namespace MSGO.Core.Utils;

public abstract class PacketHandler<TPacket> : IPacketHandler<TPacket> where TPacket : BasePacket
{
    public abstract IEnumerable<PacketRequest> HandledPacketIds { get; }
    public abstract void Handle(BaseSession session, TPacket packet);
    public virtual bool CanHandle(BaseSession session) => true;
    public virtual bool CanHandle(BaseSession session, PacketRequest packetRequest) =>
        HandledPacketIds.Contains(packetRequest);

    public void SendAsync(BaseSession session, BasePacket packet) =>
        session.SendAsync(packet.Write());
}