using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Responses;

public class GetPilotListResponse : BasePacket
{

    public GetPilotListResponse() : base(0xE1EA)
    {
        PacketBuffer.WriteUInt32(0); // result
        
        // write 424 bytes of zeroes
        for (int i = 0; i < 424; i++)
        {
            PacketBuffer.WriteByte(0);
        }
        
        for (int i = 0; i < 424; i++)
        {
            PacketBuffer.WriteByte(0);
        }

        PacketBuffer.WriteInt32(0); // del_remain_sec_eff
        PacketBuffer.WriteInt32(0); // del_remain_sec_zeon
        PacketBuffer.WriteInt32(0); // pilot_rename_remaintime_eff
        PacketBuffer.WriteInt32(0); // pilot_rename_remaintime_zeon
        PacketBuffer.WriteInt32(0); // charge_point
        
        PacketBuffer.WriteInt32(1); // bmgpack_count
        for (int i = 0; i < 36; i++)
        {
            PacketBuffer.WriteByte(0);
        }
        
        PacketBuffer.WriteByte(0); // is_tutorial_end
        PacketBuffer.WriteUInt32(0); // pilot_rename_price
        PacketBuffer.WriteUInt32(0); // pilot_rename_time_efsf
        PacketBuffer.WriteUInt32(0); // pilot_rename_forbidtime_efsf
        PacketBuffer.WriteUInt32(0); // pilot_rename_time_zeon
        PacketBuffer.WriteUInt32(0); // pilot_rename_forbidtime_zeon
    }
}