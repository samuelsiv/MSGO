using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Responses;

public class GetAdopIgnoreListResponse : BasePacket
{
    public GetAdopIgnoreListResponse() : base(0x530D)
    {
        PacketBuffer.WriteInt32(0); //Count of ignored players
        // PacketBuffer.WriteInt32(0); // for every pplayer id
    }
}