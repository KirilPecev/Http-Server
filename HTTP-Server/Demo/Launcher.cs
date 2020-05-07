namespace Demo
{
    using Controllers;
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            ServerRoutingTable routingTable = new ServerRoutingTable();
            routingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();

            Server server = new Server(8000, routingTable);

            server.Run();
        }
    }
}
