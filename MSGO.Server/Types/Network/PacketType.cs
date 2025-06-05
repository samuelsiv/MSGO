namespace MSGO.Server.Types.Network;

public enum PacketRequest : ushort
{
    AUTH_VersionCheck = 0x34A9,
    AUTH_Login = 0xF24B,
    AUTH_GetWorldList = 0x8288,
    AUTH_SelectWorld = 0xA380,
}

public enum PacketResponse : ushort
{
    AUTH_VersionCheck = 0xDE24,
    AUTH_Login = 0xA5DA,
    AUTH_GetWorldList = 0x298E,
    AUTH_SelectWorld = 0x1146,
}