namespace MSGO.Server.Packets.Responses;

public class VersionCheckResponse : BasePacket
{
    public VersionCheckResponse() : base(0xDE24)
    {
        PacketBuffer.WriteInt32(1005); // version
        PacketBuffer.WriteInt32(1720637449); // crc field
        PacketBuffer.WriteInt32(0); // gentime field
    }
}