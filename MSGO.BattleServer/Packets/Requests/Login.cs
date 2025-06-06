using MSGO.Core.Packets;
using MSGO.Core.Types.Game;

namespace MSGO.BattleServer.Packets.Requests;

public class LoginRequest : BasePacket
{
    int UserId { get; }
    string Otp { get; }

    public LoginRequest(byte[] data) : base(data)
    {
        UserId = PacketBuffer.ReadInt32();
        Otp = PacketBuffer.ReadCString();
    }

    public override string ToString() =>
        $"UserId: {UserId}, Otp: {Otp}";
}