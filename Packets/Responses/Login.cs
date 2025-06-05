using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGO.Server.Packets.Responses;

public class LoginResponse : BasePacket
{

    public LoginResponse() : base(0xA5DA)
    {
        PacketBuffer.WriteInt32(0x01);
    }
}
