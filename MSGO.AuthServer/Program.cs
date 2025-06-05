using System.Net;
using System.Reflection;
using MSGO.AuthServer;
using MSGO.Core;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Types.Interfaces;
using MSGO.Core.Utils;

Logger.Initialize();
Logger.Information("MSGO Authentication Server starting...");

PacketHandlerRegistry.RegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());
AuthServer server = new(IPAddress.Any, 50000);
ServerUtils.RunMainLoop(server);