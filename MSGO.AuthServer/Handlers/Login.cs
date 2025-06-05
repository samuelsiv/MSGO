using MSGO.AuthServer.Packets.Requests;
using MSGO.AuthServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.AuthServer.Handlers.Generic;
public class LoginHandler : PacketHandler<LoginRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.Login];
    public override void Handle(BaseSession session, LoginRequest packet)
    {
        SendAsync(session, new LoginResponse());
    }
}