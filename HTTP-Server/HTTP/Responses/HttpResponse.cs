namespace HTTP.Responses
{
    using Common;
    using Enums;
    using Extensions;
    using Headers;
    using System;
    using System.Linq;
    using System.Text;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
             => this.Headers.Add(header);

        public byte[] GetBytes()
            => Encoding
                    .ASCII
                    .GetBytes(this.ToString())
                .Concat(this.Content)
                .ToArray();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder
                .AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .Append(this.Headers).Append(Environment.NewLine)
                .AppendLine();

            return builder.ToString();
        }
    }
}
