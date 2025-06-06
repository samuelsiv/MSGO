﻿using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.AuthServer.Packets.Requests;

public class VersionCheckRequest : BasePacket
{
    public uint Version { get; set; }
    public uint Crc { get; set; }
    public uint GenTime { get; set; }

    public VersionCheckRequest(byte[] data) : base(data)
    {
        Version = PacketBuffer.ReadUInt32();
        Crc = PacketBuffer.ReadUInt32();
        GenTime = PacketBuffer.ReadUInt32();
    }

    public override string ToString() =>
        $" Version: {Version}, Crc: {Crc}, GenTime: {GenTime}";
}