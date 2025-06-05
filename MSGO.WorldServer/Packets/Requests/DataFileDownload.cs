using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Requests;

public class DataFileDownloadRequest : BasePacket
{
    public string FilePath { get; }
    int HashVal { get; }

    public DataFileDownloadRequest(byte[] data) : base(data)
    {
        FilePath = PacketBuffer.ReadCString();
        HashVal = PacketBuffer.ReadInt32();
    }

    public override string ToString() =>
        $"FilePath: {FilePath}, HashVal: {HashVal}";
}