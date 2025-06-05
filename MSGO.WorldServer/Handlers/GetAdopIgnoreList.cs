using MSGO.Core.Packets;
using MSGO.WorldServer.Packets.Requests;
using MSGO.WorldServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.WorldServer.Handlers;

public class GetAdopIgnoreList : PacketHandler<GetAdopIgnoreListRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [ PacketRequest.GetAdopIgnoreList ];
    public override void Handle(BaseSession session, GetAdopIgnoreListRequest packet)
    {
        SendAsync(session, new GetAdopIgnoreListResponse());
    }
}
