using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PhoenixTS93
{
    public static class PhoenixClientFinder
    {
        public static List<string> FindPhoenixClients()
        {
            var clients = new List<string>();
            string ipcPath = @"C:\ProgramData\PhoenixBot\PhoenixIPC.json";

            if (!File.Exists(ipcPath))
            {
                File.AppendAllText("debug.log", "[Finder] Nie znaleziono pliku IPC\n");
                return clients;
            }

            try
            {
                var content = File.ReadAllText(ipcPath);
                var ipcData = JsonSerializer.Deserialize<Dictionary<string, object>>(content);

                if (ipcData != null && ipcData.ContainsKey("port"))
                {
                    int port = Convert.ToInt32(ipcData["port"]);
                    clients.Add($"127.0.0.1:{port}");
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("debug.log", $"[Finder Error] {ex.Message}\n");
            }

            return clients;
        }
    }
}