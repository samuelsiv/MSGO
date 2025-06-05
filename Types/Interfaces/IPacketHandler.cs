using MSGO.Server.Packets;
using MSGO.Server.Sessions;
using MSGO.Server.Types.Network;
using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGO.Server.Types.Interfaces;

public interface IPacketHandler<in TPacket> where TPacket : BasePacket
{
    IEnumerable<PacketRequest> HandledPacketIds { get; }
    void Handle(BaseSession session, TPacket packet);
    bool CanHandle(BaseSession session);
    bool CanHandle(BaseSession session, PacketRequest packetRequest);
}