using MSGO.Server.Sessions;
using MSGO.Server.Types.Interfaces;
using MSGO.Server.Types.Network;
using System.Reflection;

namespace MSGO.Server.Packets.Handlers;

public class PacketHandlerRegistry
{
    private static readonly List<IPacketHandler<BasePacket>> _handlers = new();

    public static void RegisterHandler<TPacket>(IPacketHandler<TPacket> handler) where TPacket : BasePacket =>
        _handlers.Add(new PacketHandlerWrapper<TPacket>(handler));


    public static void HandlePacket(BaseSession session, BasePacket packet, PacketRequest packetRequest, byte[] rawData)
    {
        foreach (var handler in _handlers)
        {
            if (handler.CanHandle(session, packetRequest))
                handler.Handle(session, packet);
        }
    }

    private class PacketHandlerWrapper<TPacket> : IPacketHandler<BasePacket> where TPacket : BasePacket
    {
        private readonly IPacketHandler<TPacket> _inner;

        public PacketHandlerWrapper(IPacketHandler<TPacket> inner) =>
            _inner = inner;

        public IEnumerable<PacketRequest> HandledPacketIds =>
            _inner.HandledPacketIds;

        public void Handle(BaseSession session, BasePacket packet)
        {
            ConstructorInfo? constructor = typeof(TPacket).GetConstructor([typeof(byte[])]);
            if (constructor == null)
                throw new InvalidOperationException($"Type {typeof(TPacket).Name} does not have a constructor that takes a single byte[] argument.");

            TPacket typedPacket = (TPacket)constructor.Invoke([packet.PacketBuffer.GetAllBytes()]);
            _inner.Handle(session, typedPacket);
        }

        public bool CanHandle(BaseSession session) =>
            _inner.CanHandle(session);

        public bool CanHandle(BaseSession session, PacketRequest packetRequest) =>
            _inner.CanHandle(session, packetRequest);
    }
}