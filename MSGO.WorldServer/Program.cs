using System.Net;
using System.Reflection;
using MSGO.Core;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Utils;
using MSGO.WorldServer;

Logger.Initialize();
Logger.Information("MSGO World Server starting...");

PacketHandlerRegistry.RegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());
WorldServer server = new(IPAddress.Any, 6969);
ServerUtils.RunMainLoop(server);