namespace WebServer.Routing
{
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Responses;
    using System;
    using System.Collections.Generic;

    public class ServerRoutingTable
    {
        public ServerRoutingTable()
        {
            this.Routes = new Dictionary<HttpRequestMethod, IDictionary<string, Func<IHttpRequest, IHttpResponse>>>()
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }

        public IDictionary<HttpRequestMethod, IDictionary<string, Func<IHttpRequest, IHttpResponse>>> Routes { get; set; }
    }
}
