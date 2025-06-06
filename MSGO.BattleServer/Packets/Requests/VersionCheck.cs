using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.BattleServer.Packets.Requests;

public class VersionCheckRequest : BasePacket
{
    uint Version { get; set; } 
    uint Crc { get; set; } 
    uint GenTime { get; set; }

    public VersionCheckRequest(byte[] data) : base(data)
    {
        Version = PacketBuffer.ReadUInt32();
        Crc = PacketBuffer.ReadUInt32();
        GenTime = PacketBuffer.ReadUInt32();
    }

    public override string ToString() => 
        $"Version: {Version}, Crc: {Crc}, GenTime: {GenTime}";
}