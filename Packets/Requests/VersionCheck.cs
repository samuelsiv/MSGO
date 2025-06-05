using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MSGO.Server.Packets.Requests;

public class VersionCheckRequest : BasePacket
{
    public uint Version { get; set; }
    public uint Crc { get; set; }
    public uint GetNTime { get; set; }

    public VersionCheckRequest(byte[] data) : base(data)
    {
        Version = PacketBuffer.ReadUInt32();
        Crc = PacketBuffer.ReadUInt32();
        GetNTime = PacketBuffer.ReadUInt32();
    }

    public override string ToString()
    {
        return $"VersionCheck - Version: {Version}, Crc: {Crc}, GetNTime: {GetNTime}";
    }
}