using MSGO.BattleServer.Packets.Requests;
using MSGO.BattleServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.BattleServer.Handlers;

public class VersionCheckHandler : PacketHandler<VersionCheckRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.VersionCheck];
    public override void Handle(BaseSession session, VersionCheckRequest packet)
    {
        SendAsync(session, new VersionCheckResponse());
    }
}