using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MSGO.Server.Packets.Requests;

class WorldListRequest : BasePacket
{
    public WorldListRequest(byte[] data) : base(data)
    {
    }

    public override string ToString()
    {
        return $"WorldListRequest";
    }
}