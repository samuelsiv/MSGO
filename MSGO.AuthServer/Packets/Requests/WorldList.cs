using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.AuthServer.Packets.Requests;
public class WorldListRequest(byte[] data) : BasePacket(data)
{
    public override string ToString() =>
        "WorldListRequest";
}