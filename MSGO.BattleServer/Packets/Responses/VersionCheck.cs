using MSGO.Core.Packets;

namespace MSGO.BattleServer.Packets.Responses;
public class VersionCheckResponse : BasePacket
{
    public VersionCheckResponse() : base(0xDE24)
    {
        /* taken from world server, but we don't know this as of rn */
        PacketBuffer.WriteInt32(2024); // version
        PacketBuffer.WriteInt32(1578124434); // crc field
        PacketBuffer.WriteInt32(0); // gentime field
    }
}