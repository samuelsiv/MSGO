using MSGO.WorldServer.Packets.Requests;
using MSGO.WorldServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.WorldServer.Handlers;

public class DataFileDownload : PacketHandler<DataFileDownloadRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [ PacketRequest.DataFileDownload ];
    public override void Handle(BaseSession session, DataFileDownloadRequest packet)
    {
        SendAsync(session, new DataFileDownloadResponse(packet.FilePath));
    }
}
