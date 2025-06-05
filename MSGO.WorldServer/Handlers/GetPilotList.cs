using MSGO.WorldServer.Packets.Requests;
using MSGO.WorldServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.WorldServer.Handlers;

public class GetPilotList : PacketHandler<GetPilotListRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [ PacketRequest.GetPilotList ];
    public override void Handle(BaseSession session, GetPilotListRequest packet)
    {
        SendAsync(session, new GetPilotListResponse());
    }
}
