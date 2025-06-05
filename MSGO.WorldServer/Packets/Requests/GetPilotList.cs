using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.WorldServer.Packets.Requests;

public class GetPilotListRequest(byte[] data) : BasePacket(data);