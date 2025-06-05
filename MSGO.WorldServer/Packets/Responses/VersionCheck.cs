using MSGO.Core.Packets;

namespace MSGO.WorldServer.Packets.Responses;
public class VersionCheckResponse : BasePacket
{
    public VersionCheckResponse() : base(0xDE24)
    {
        PacketBuffer.WriteInt32(2024); // version
        PacketBuffer.WriteInt32(1578124434); // crc field
        PacketBuffer.WriteInt32(0); // gentime field
    }
}