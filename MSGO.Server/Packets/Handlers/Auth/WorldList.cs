using MSGO.Server.Packets.Requests;
using MSGO.Server.Packets.Responses;
using MSGO.Server.Sessions;
using MSGO.Server.Types.Game;
using MSGO.Server.Types.Network;
using MSGO.Server.Utils;

namespace MSGO.Server.Packets.Handlers.Auth;

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