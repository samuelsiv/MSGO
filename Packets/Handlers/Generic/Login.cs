using MSGO.Server.Packets.Requests;
using MSGO.Server.Packets.Responses;
using MSGO.Server.Sessions;
using MSGO.Server.Types;
using MSGO.Server.Types.Network;
using MSGO.Server.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGO.Server.Packets.Handlers.Generic;

public class LoginHandler : PacketHandler<LoginRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => new[] { 
        PacketRequest.AUTH_Login 
    };
    public override void Handle(BaseSession session, LoginRequest packet)
    {
        Console.WriteLine(packet.ToString());
        session.SendAsync(new LoginResponse().Write());
    }
}