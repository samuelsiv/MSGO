using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGO.Server.Packets.Requests;

public class LoginRequest : BasePacket
{
    public string LoginId { get; set; }
    public string LoginPw { get; set; }
    public string DiskUuid { get; set; }
    public string MacAddr { get; set; }

    public LoginRequest(byte[] data) : base(data)
    {
        LoginId = PacketBuffer.ReadCString();
        LoginPw = PacketBuffer.ReadCString();
        DiskUuid = PacketBuffer.ReadCString();
        MacAddr = PacketBuffer.ReadCString();
    }

    public override string ToString()
    {
        return $"LoginPacket - LoginId: {LoginId}, LoginPw: {LoginPw}, DiskUuid: {DiskUuid}, MacAddr: {MacAddr}";
    }
}