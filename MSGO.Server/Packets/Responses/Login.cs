namespace MSGO.Server.Packets.Responses;

public class LoginResponse : BasePacket
{
    public LoginResponse() : base(0xA5DA) =>
        PacketBuffer.WriteInt32(0x00);
}
