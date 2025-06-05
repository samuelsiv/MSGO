using MSGO.Server.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SelectWorldRequest : BasePacket
{
    public uint WorldNum { get; set; }

    public SelectWorldRequest(byte[] data) : base(data)
    {
        WorldNum = PacketBuffer.ReadUInt32();
    }

    public override string ToString()
    {
        return $"WorldSelectRequest - WorldNum: {WorldNum},";
    }
}