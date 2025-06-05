using MSGO.AuthServer.Packets.Requests;
using MSGO.AuthServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Game;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.AuthServer.Handlers.Auth;
public class SelectWorldHandler : PacketHandler<SelectWorldRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.SelectWorld];

    public override void Handle(BaseSession session, SelectWorldRequest packet)
    {
        World world = new(1, "test", "test", "test2", 1, 1, 12, 120, "localhost", 6969);
        SendAsync(session, new SelectWorldResponse(0, world, 1, "1234"));
    }
}