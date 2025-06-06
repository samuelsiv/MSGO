using MSGO.BattleServer.Packets.Requests;
using MSGO.BattleServer.Packets.Responses;
using MSGO.Core.Sessions;
using MSGO.Core.Types.Network;
using MSGO.Core.Utils;

namespace MSGO.BattleServer.Handlers;

public class LoginHandler : PacketHandler<LoginRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => [ PacketRequest.Login ];
    public override void Handle(BaseSession session, LoginRequest packet)
    {
        SendAsync(session, new LoginResponse());
    }
}