using MSGO.WorldServer.Packets.Requests;
using MSGO.WorldServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.WorldServer.Handlers;

public class VersionCheckHandler : PacketHandler<VersionCheckRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.AUTH_VersionCheck];
    public override void Handle(BaseSession session, VersionCheckRequest packet)
    {
        SendAsync(session, new VersionCheckResponse());
    }
}