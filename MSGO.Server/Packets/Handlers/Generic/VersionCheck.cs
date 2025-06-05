using MSGO.Server.Packets.Requests;
using MSGO.Server.Packets.Responses;
using MSGO.Server.Sessions;
using MSGO.Server.Types.Network;
using MSGO.Server.Utils;

namespace MSGO.Server.Packets.Handlers.Generic;

public class VersionCheckHandler : PacketHandler<VersionCheckRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.AUTH_VersionCheck];
    public override void Handle(BaseSession session, VersionCheckRequest packet)
    {
        Console.WriteLine("Version handler");
        SendAsync(session, new VersionCheckResponse());
    }
}