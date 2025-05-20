using SuperSimpleTcp;

namespace PhoenixTS93
{
    public class PhoenixClient
    {
        private SimpleTcpClient client;

        public PhoenixClient(string ip, int port)
        {
            client = new SimpleTcpClient($"{ip}:{port}");
        }

        public void Connect()
        {
            client.Connect();
        }

        public void Send(string message)
        {
            client.Send(message);
        }
    }
}