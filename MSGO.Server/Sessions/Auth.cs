using MSGO.Server.Packets;
using MSGO.Server.Packets.Handlers;
using MSGO.Server.Types.Network;
using NetCoreServer;
using System.Net.Sockets;

namespace MSGO.Server.Sessions;

public class AuthSession : BaseSession
{
    public AuthSession(TcpServer server) : base(server) { }

    private int _receivedPackets;
    private bool _isFirstPacket = true;

    protected void HandlePacketOld(BasePacket packet, byte[] rawData)
    {
        /*
        switch ((PacketRequest)packet.PacketId)
        {
            case PacketRequest.AUTH_VersionCheck:
                {
                    var parsedPacket = new VersionCheckRequest(rawData);
                    var response = new VersionCheckResponse();
                    SendAsync(response.Write());
                    break;
                }
            case PacketRequest.AUTH_Login:
                {
                    var parsedPacket = new LoginRequest(rawData);
                    var response = new LoginResponse();
                    SendAsync(response.Write());
                    break;
                }
            case PacketRequest.AUTH_GetWorldList:
                {
                    var response = new WorldListResponse();
                    SendAsync(response.Write());
                    break;
                }
            case PacketRequest.AUTH_SelectWorld:
                {
                    var parsedPacket = new SelectWorldRequest(rawData);
                    var response = new WorldSelectResponse(1, "test", "127.0.0.1", 50001, 1, "");
                    SendAsync(response.Write());
                    break;
                }
            default:
                break;
        }*/

    }

    protected override void HandlePacket(BasePacket packet, byte[] rawData) =>
        PacketHandlerRegistry.HandlePacket(this, packet, (PacketRequest)packet.PacketId, rawData);

    protected override void OnError(SocketError error) =>
        Console.WriteLine($"Auth Server session caught an error with code {error}");
}