namespace MSGO.Server.Packets.Requests;

public class WorldListRequest : BasePacket
{
    public WorldListRequest(byte[] data) : base(data) { }
    public override string ToString() =>
        "WorldListRequest";
}