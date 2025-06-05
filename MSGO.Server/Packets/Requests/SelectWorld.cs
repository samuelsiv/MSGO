using MSGO.Server.Packets;

public class SelectWorldRequest : BasePacket
{
    public uint WorldNum { get; set; }
    public SelectWorldRequest(byte[] data) : base(data) =>
        WorldNum = PacketBuffer.ReadUInt32();

    public override string ToString() =>
        $"WorldSelectRequest - WorldNum: {WorldNum},";
}