using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Responses;

public class DataFileDownloadResponse : BasePacket
{
    /*
    int Result { get; }
    public string FilePath { get; }
    public int HashVal { get; }
    
    List<byte> Data { get; }
    
    bool Compress { get; }
    */

    public DataFileDownloadResponse() : base(0x5290)
    {
        PacketBuffer.WriteInt32(0);
        PacketBuffer.WriteCString("autoexec_sv.cfg");
        PacketBuffer.WriteInt32(0);
        PacketBuffer.WriteInt32(0);
        PacketBuffer.WriteInt32(0);
    }
}