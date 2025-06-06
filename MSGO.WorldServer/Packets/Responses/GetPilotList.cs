using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Responses;

public class GetPilotListResponse : BasePacket
{

    public GetPilotListResponse() : base(0xE1EA)
    {
        PacketBuffer.WriteUInt32(0); // result
        
        // EFF pilots list
        PacketBuffer.WriteUInt32(0); // pilots_eff count
        // write 14 bytes for each pilot 00
        //PacketBuffer.WriteBytes(new byte[420]);
        
        // Zeon pilots list  
        PacketBuffer.WriteUInt32(0); // pilots_zeon count
        //PacketBuffer.WriteBytes(new byte[420]);
        // Write pilot data here if count > 0
        
        PacketBuffer.WriteUInt32(0); // del_remain_sec_eff
        PacketBuffer.WriteUInt32(0); // del_remain_sec_zeon
        PacketBuffer.WriteUInt32(0); // pilot_rename_remaintime_eff
        PacketBuffer.WriteUInt32(0); // pilot_rename_remaintime_zeon
        PacketBuffer.WriteUInt32(0); // charge_point
        PacketBuffer.WriteUInt32(1); // bmgpack_count
        PacketBuffer.WriteByte(0); // is_tutorial_end
        PacketBuffer.WriteUInt32(0); // pilot_rename_price
        PacketBuffer.WriteUInt32(0); // pilot_rename_time_efsf
        PacketBuffer.WriteUInt32(0); // pilot_rename_forbidtime_efsf
        PacketBuffer.WriteUInt32(0); // pilot_rename_time_zeon
        PacketBuffer.WriteUInt32(0); // pilot_rename_forbidtime_zeon
    }
}