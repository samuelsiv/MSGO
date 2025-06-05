namespace MSGO.Core.Types.Network;

public enum PacketRequest : ushort
{
    VersionCheck = 0x34A9,
    Login = 0xF24B, 
    GetWorldList = 0x8288,
    SelectWorld = 0xA380,
    
    DataFileDownload = 0xF86A,
    GetAdopIgnoreList = 0xA085,
    GetPilotList = 0x60CD
}

public enum PacketResponse : ushort
{
    AUTH_VersionCheck = 0xDE24,
    AUTH_Login = 0xA5DA,
    AUTH_GetWorldList = 0x298E,
    AUTH_SelectWorld = 0x1146,
}