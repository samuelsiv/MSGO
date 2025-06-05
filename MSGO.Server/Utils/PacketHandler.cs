using MSGO.Server.Packets;
using MSGO.Server.Sessions;
using MSGO.Server.Types.Interfaces;
using MSGO.Server.Types.Network;

namespace MSGO.Server.Utils;

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

public abstract class PacketHandler<TSession, TPacket> : PacketHandler<TPacket>
    where TSession : BaseSession
    where TPacket : BasePacket
{
    public abstract void Handle(TSession session, TPacket packet);
    public override void Handle(BaseSession session, TPacket packet)
    {
        if (session is not TSession typedSession)
            throw new InvalidOperationException($"Expected session of type {typeof(TSession).Name}, but got {session.GetType().Name}");

        Handle(typedSession, packet);
    }

    public override bool CanHandle(BaseSession session) => session is TSession;
    public override bool CanHandle(BaseSession session, PacketRequest packetRequest) => session is TSession && HandledPacketIds.Contains(packetRequest);
}