using Arrowgene.Buffers;
using MSGO.Server.Utils;

namespace MSGO.Server.Packets;

public class BasePacket
{
    private const int PACKET_ID_SIZE = 2;

    private IBuffer _packetBuffer;
    private int _payloadLength;
    private UInt32 _fullPacketSize;
    private UInt16 _packetId;

    public IBuffer PacketBuffer => _packetBuffer;
    public int PayloadLength => _payloadLength;
    public UInt32 FullPacketSize => _fullPacketSize;
    public UInt16 PacketId => _packetId;
    public int PayloadPosition => _packetBuffer.Position - PACKET_ID_SIZE;

    public BasePacket(byte[] fullPacket)
    {
        _packetBuffer = new StreamBuffer(fullPacket); _packetBuffer.SetPositionStart();
        _fullPacketSize = _packetBuffer.ReadUInt32();

        int sizeHeaderLength = _packetBuffer.ReadByte();
        if (sizeHeaderLength == 0)
        {
            _payloadLength = _packetBuffer.ReadByte();
        }
        else
        {
            for (int i = 0; i < sizeHeaderLength + 1; i++)
            {
                _payloadLength |= _packetBuffer.ReadByte() << (i * 8);
            }
        }

        _packetId = _packetBuffer.ReadUInt16(Endianness.Little);
    }

    public BasePacket(UInt16 packetId)
    {
        _packetBuffer = BufferProvider.Provide();
        _packetBuffer.WriteUInt16(packetId);
        _packetId = packetId;
    }

    public byte[] Write()
    {
        IBuffer headBuffer = BufferProvider.Provide();

        _payloadLength = PacketBuffer.Size;

        int sizeHeaderLength = 0;
        int payloadLength = _payloadLength;
        do
        {
            payloadLength >>= 8;
            sizeHeaderLength++;
        } while (payloadLength != 0);

        if (sizeHeaderLength == 1)
            headBuffer.WriteByte(0x00); // 0 if it occupies only the next byte
        else
            headBuffer.WriteByte((byte)(sizeHeaderLength - 1));
        
        payloadLength = _payloadLength;
        for (int i = 0; i < sizeHeaderLength; i++)
        {
            headBuffer.WriteByte((byte)(payloadLength & 0xFF));
            payloadLength >>= 8;
        }

        IBuffer mixedBuffer = MergeBuffers(headBuffer, _packetBuffer);

        _fullPacketSize = (uint)mixedBuffer.Size;

        int remainder = mixedBuffer.Size & 0xF;
        if (remainder != 0)
        {
            int paddingNeeded = 16 - remainder;
            Random rng = new Random();
            for (int i = 0; i < paddingNeeded; i++) 
                mixedBuffer.WriteByte((byte)rng.Next(256));
        }

        IBuffer firstHeadBuffer = BufferProvider.Provide();
        firstHeadBuffer.WriteUInt32(_fullPacketSize);

        mixedBuffer = MergeBuffers(firstHeadBuffer, mixedBuffer);

        return mixedBuffer.GetAllBytes();
    }

    private IBuffer MergeBuffers(IBuffer bufferOne, IBuffer bufferTwo)
    {
        IBuffer mergedBuffer = BufferProvider.Provide();
        mergedBuffer.WriteBytes(bufferOne.GetAllBytes());
        mergedBuffer.WriteBytes(bufferTwo.GetAllBytes());
        return mergedBuffer;
    }
}