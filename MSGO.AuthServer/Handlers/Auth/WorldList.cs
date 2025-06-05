using MSGO.AuthServer.Packets.Requests;
using MSGO.AuthServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Game;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.AuthServer.Handlers.Auth;

public class WorldListHandler : PacketHandler<WorldListRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.AUTH_GetWorldList];
    public override void Handle(BaseSession session, WorldListRequest packet)
    {
        Console.WriteLine("WorldListRequest");

        var world = new World(1, "test", "test", "test2", 1, 1, 12, 120, "localhost", 6969);

        session.SendAsync(new WorldListResponse(0, 0, [world]).Write());
    }
}