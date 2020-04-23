namespace WebServer
{
    using Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener tcpListener;

        private readonly ServerRoutingTable routingTable;

        private bool isRunning;

        public Server(int port, ServerRoutingTable routingTable)
        {
            this.port = port;
            this.routingTable = routingTable;

            this.tcpListener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");

            Task task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.tcpListener.AcceptSocketAsync();
                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.routingTable);
                Task responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }
    }
}
