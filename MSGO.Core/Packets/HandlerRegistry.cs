using MSGO.Core.Sessions;
using MSGO.Core.Types.Interfaces;
using MSGO.Core.Types.Network;
using System.Reflection;

namespace MSGO.Core.Packets.Handlers;

public class PacketHandlerRegistry
{
    private static readonly List<IPacketHandler<BasePacket>> _handlers = new();

    public static void RegisterHandler<TPacket>(IPacketHandler<TPacket> handler) where TPacket : BasePacket =>
        _handlers.Add(new PacketHandlerWrapper<TPacket>(handler));
    
    public static void RegisterHandlersFromAssembly(Assembly assembly)
    {
        foreach (var type in assembly.GetTypes())
        {
            if (!type.IsAbstract && !type.IsGenericTypeDefinition && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>)))
            {
                var handler = Activator.CreateInstance(type);
                var packetType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPacketHandler<>)).GetGenericArguments()[0];
                typeof(PacketHandlerRegistry).GetMethod(nameof(RegisterHandler))!.MakeGenericMethod(packetType).Invoke(null, [handler]);
                Logger.Debug($"Registering handler for packet type: {packetType.Name}");
            }
        }
    }
    
    public static void HandlePacket(BaseSession session, BasePacket packet, PacketRequest packetRequest, byte[] rawData)
    {
        var allowedHandlers = _handlers
            .Where(h => h.CanHandle(session, packetRequest))
            .ToList();
        
        if (allowedHandlers.Count == 0)
        {
            Logger.Error("No handler found for packet {Packet}", packet);
            return;
        }
        
        foreach (var handler in allowedHandlers)
            handler.Handle(session, packet);
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
            
            Logger.Debug(typedPacket);
        }

        public bool CanHandle(BaseSession session) =>
            _inner.CanHandle(session);

        public bool CanHandle(BaseSession session, PacketRequest packetRequest) =>
            _inner.CanHandle(session, packetRequest);
    }
}