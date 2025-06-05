using MSGO.Core.Packets;

namespace MSGO.Core;

using Serilog;

public static class Logger
{
    public static void Initialize()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            //.WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
    
    public static void Debug(string message, params object[] args) => Log.Debug(message, args);
    public static void Information(string message, params object[] args) => Log.Information(message, args);
    public static void Warning(string message, params object[] args) => Log.Warning(message, args);
    public static void Error(string message, params object[] args) => Log.Error(message, args);
    public static void Fatal(string message, params object[] args) => Log.Fatal(message, args);
    public static void Verbose(string message, params object[] args) => Log.Verbose(message, args);
    
    public static void Information(BasePacket packet) => Log.Information("Packet: {PacketId} ({PacketName}) - {PacketData}", packet.PacketId, packet.GetType().Name, packet);
    public static void Debug(BasePacket packet) => Log.Debug("Handled Packet: 0x{PacketId:X2} ({PacketName}) - {PacketData}", packet.PacketId, packet.GetType().Name, packet);
    public static void Warning(BasePacket packet) => Log.Warning("Handled Packet: 0x{PacketId:X2}  ({PacketName}) - {PacketData}", packet.PacketId, packet.GetType().Name, packet);
    public static void Error(BasePacket packet) => Log.Error("Handled Packet: 0x{PacketId:X2}  ({PacketName}) - {PacketData}", packet.PacketId, packet.GetType().Name, packet);
    public static void Fatal(BasePacket packet) => Log.Fatal("Handled Packet: 0x{PacketId:X2} ({PacketName}) - {PacketData}", packet.PacketId, packet.GetType().Name, packet);
    public static void Verbose(BasePacket packet) => Log.Verbose("Handled Packet: 0x{PacketId:X2}  ({PacketName}) - {PacketData}", packet.PacketId, packet.GetType().Name, packet);
}