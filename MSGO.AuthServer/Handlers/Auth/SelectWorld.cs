using MSGO.AuthServer.Packets.Requests;
using MSGO.AuthServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Game;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.AuthServer.Handlers.Auth;
public class SelectWorldHandler : PacketHandler<SelectWorldRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.AUTH_SelectWorld];

    public override void Handle(BaseSession session, SelectWorldRequest packet)
    {
        Console.WriteLine("SelectWorldHandler");

        var world = new World(1, "test", "test", "test2", 1, 1, 12, 120, "localhost", 6969);

        session.SendAsync(new SelectWorldResponse(0, world, 1, "1234").Write());
    }
}