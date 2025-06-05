using Arrowgene.Buffers;
using MSGO.Core.Types.Interfaces;
using MSGO.Core.Utils;

namespace MSGO.Core.Types.Game;

public class World(uint worldId, string name, string nameEn, string description, byte status, ushort iconId, uint currentPlayerCount, uint maxPlayerCount, string host, int port) : ISerializable
{
    uint WorldId { get; set; } = worldId;
    public string Name { get; set; } = name;
    public string NameEn { get; set; } = nameEn;
    string Description { get; set; } = description;
    uint Status { get; set; } = status;
    ushort IconId { get; set; } = iconId;
    uint CurrentPlayerCount { get; set; } = currentPlayerCount;
    uint MaxPlayerCount { get; set; } = maxPlayerCount;

    public string Host { get; set; } = host;
    public int Port { get; set; } = port;

    public IBuffer Serialize()
    {
        IBuffer buffer = BufferProvider.Provide();

        buffer.WriteUInt32(WorldId);
        buffer.WriteFixedString(Name, 49);
        buffer.WriteFixedString(NameEn, 49);
        buffer.WriteFixedString(Description, 193);
        buffer.WriteUInt32(Status);
        buffer.WriteUInt16(IconId);
        buffer.WriteUInt32(CurrentPlayerCount);
        buffer.WriteUInt32(MaxPlayerCount);

        return buffer;
    }
}
