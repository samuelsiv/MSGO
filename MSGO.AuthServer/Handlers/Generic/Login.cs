using MSGO.AuthServer.Packets.Requests;
using MSGO.AuthServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.AuthServer.Handlers.Generic;
public class LoginHandler : PacketHandler<LoginRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [PacketRequest.AUTH_Login];
    public override void Handle(BaseSession session, LoginRequest packet)
    {
        Console.WriteLine(packet.ToString());
        session.SendAsync(new LoginResponse().Write());
    }
}