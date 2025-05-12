using System;
using System.IO;
using SuperSimpleTcp;
using Newtonsoft.Json;

namespace PhoenixTS93
{
    public class PhoenixClient
    {
        private readonly string _endpoint;
        private readonly SimpleTcpClient _client;

        public PhoenixClient(string endpoint)
        {
            _endpoint = endpoint;
            _client = new SimpleTcpClient(_endpoint);
        }

        public bool Connect()
        {
            try
            {
                _client.Connect();
                return true;
            }
            catch (Exception ex)
            {
                File.AppendAllText("debug.log", $"[Connect Error] {ex.Message}\n");
                return false;
            }
        }

        public void RunTS93()
        {
            try
            {
                var msg = new
                {
                    opcode = "run_ts93",
                    data = "start"
                };
                string json = JsonConvert.SerializeObject(msg) + "\x01";
                _client.Send(json);
                File.AppendAllText("debug.log", "[RunTS93] Wysłano komendę do klienta\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("debug.log", $"[RunTS93 Error] {ex.Message}\n");
            }
        }
    }
}