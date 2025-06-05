using MSGO.Server.Types.Game;

namespace MSGO.Server.Packets.Responses;

public class WorldListResponse : BasePacket
{
    Int32 Result;
    Int32 LastWorld;
    Int32 WorldCount;
    List<World> Worlds = new List<World>();

    /*
    public WorldListResponse() : base(0x298E)
    {
        PacketBuffer.WriteInt32(0x00); // status
        PacketBuffer.WriteInt32(0x00); // last world
        PacketBuffer.WriteInt32(1); // World count

        var world = new World(1, "world", "w2", "test", 1, 11, 12, 33);

        PacketBuffer.WriteBuffer(world.Serialize());
    }
    */

    public WorldListResponse(Int32 result, Int32 lastWorld, List<World> worlds) : base(0x298E)
    {
        Result = result;
        LastWorld = lastWorld;
        WorldCount = worlds.Count;

        PacketBuffer.WriteInt32(Result);
        PacketBuffer.WriteInt32(LastWorld);
        PacketBuffer.WriteInt32(WorldCount);

        Worlds = worlds;
        foreach (var world in Worlds)
        {
            PacketBuffer.WriteBuffer(world.Serialize());
        }
    }
}