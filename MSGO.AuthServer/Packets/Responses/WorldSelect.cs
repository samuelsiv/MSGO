using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.AuthServer.Packets.Responses;

public class SelectWorldResponse : BasePacket
{
    Int32 Result;
    World World;
    Int32 UserId;
    string Otp;

    public SelectWorldResponse(Int32 result, World world, Int32 userId, string otp) : base(0x1146)
    {
        Result = result;
        World = world;
        UserId = userId;
        Otp = otp;

        PacketBuffer.WriteInt32(result);
        PacketBuffer.WriteCString(World.Name);
        PacketBuffer.WriteCString(World.Host);
        PacketBuffer.WriteInt32(World.Port);
        PacketBuffer.WriteInt32(UserId);
        PacketBuffer.WriteCString("1234");

        /*
        PacketBuffer.WriteInt32(0x00); // result
        PacketBuffer.WriteCString("localhost"); // name
        PacketBuffer.WriteCString("localhost");  // host
        PacketBuffer.WriteInt32(6969); // port
        PacketBuffer.WriteInt32(1337); // user id
        PacketBuffer.WriteCString("1234"); // otp
        */
    }
}