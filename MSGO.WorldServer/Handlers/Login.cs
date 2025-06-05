using MSGO.WorldServer.Packets.Requests;
using MSGO.WorldServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.WorldServer.Handlers;

public class LoginHandler : PacketHandler<LoginRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.AUTH_Login];
    public override void Handle(BaseSession session, LoginRequest packet)
    {
        SendAsync(session, new LoginResponse());
    }
}