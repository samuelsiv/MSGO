using MSGO.Core.Packets;

namespace MSGO.BattleServer.Packets.Responses;

public class LoginResponse : BasePacket
{
    public LoginResponse() : base(0xA5DA)
    {
        PacketBuffer.WriteInt32(0x00);
        PacketBuffer.WriteInt32(0x1); // admin
    }
}
