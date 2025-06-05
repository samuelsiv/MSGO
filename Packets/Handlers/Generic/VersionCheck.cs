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

public class VersionCheckHandler : PacketHandler<VersionCheckRequest>
{
    public override IEnumerable<PacketRequest> HandledPacketIds => new[] { 
        PacketRequest.AUTH_VersionCheck 
    };

    public override void Handle(BaseSession session, VersionCheckRequest packet)
    {
        Console.WriteLine("Version handler");
        session.SendAsync(new VersionCheckResponse().Write());
    }
}