// static calss Starter

using System;
using System.Reflection;
using MSGO.Core.Packets.Handlers;
using MSGO.Core.Types.Interfaces;
using NetCoreServer;

namespace MSGO.Core.Utils;

public static class ServerUtils
{
    public static void RunMainLoop(TcpServer server)
    {
        if (server == null)
            throw new ArgumentNullException(nameof(server), "Server cannot be null.");

        try
        {
            Logger.Information("Press any key to stop the server or '!' to restart...");
            
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.KeyChar == '!')
                {
                    Logger.Warning("Restarting server...");
                    server.Restart();
                    continue;
                }

                break;
            }
        }
        catch (Exception ex)
        {
            Logger.Error($"An error occurred: {ex.Message}");
        }
        finally
        {
            server.Stop();
            Logger.Information("Server stopped.");
        }
    }
}
