using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Responses;

public class DataFileDownloadResponse : BasePacket
{
    public DataFileDownloadResponse(string name) : base(0x5290)
    {
        PacketBuffer.WriteInt32(0); // Result
        PacketBuffer.WriteCString(name); // FilePath
        PacketBuffer.WriteInt32(0); // HashVal
        PacketBuffer.WriteInt32(0); // Original size of data
        PacketBuffer.WriteUInt16(0); // Compression type (0 = none, 1 = zlib)
        PacketBuffer.WriteInt32(1); // Length of data (max 128MB)
        
        PacketBuffer.WriteByte(0); // Data ---
    }
}