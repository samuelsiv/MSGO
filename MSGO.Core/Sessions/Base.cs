using MSGO.Core.Packets;
using NetCoreServer;
using System.Net.Sockets;

namespace MSGO.Core.Sessions;

public class BaseSession(TcpServer server) : TcpSession(server)
{
    private bool _isFirstPacket = true;
    protected override void OnConnected()
    {
        SendAsync(new byte[] { 0x12, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F });
        SendAsync(new byte[] { 0x01, 0x02, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F });
    }

    protected override void OnDisconnected() =>
        Console.WriteLine($"Session {Id} disconnected!");

    protected override void OnReceived(byte[] buffer, long offset, long size)
    {
        if (_isFirstPacket)
        {
            _isFirstPacket = false;
            return;
        }

        byte[] packetData = new byte[size];
        Array.Copy(buffer, offset, packetData, 0, size);

        HandlePacket(new(packetData), packetData);
    }

    protected virtual void HandlePacket(BasePacket packet, byte[] rawData) { }

    protected override void OnError(SocketError error) =>
        Console.WriteLine($"Session caught an error with code {error}");
}