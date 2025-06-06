﻿using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.AuthServer.Packets.Responses;

public class WorldListResponse : BasePacket
{
    Int32 Result;
    Int32 LastWorld;
    Int32 WorldCount;
    private List<World> Worlds;
    
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