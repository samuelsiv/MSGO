using System.Net;
using System.Reflection;
using MSGO.Core;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Utils;
using MSGO.BattleServer;

Logger.Initialize();
Logger.Information("MSGO Battle Server starting...");

PacketHandlerRegistry.RegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());
BattleServer server = new(IPAddress.Any, 6970);
ServerUtils.RunMainLoop(server);