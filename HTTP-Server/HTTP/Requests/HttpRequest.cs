namespace HTTP.Requests
{
    using Common;
    using Enums;
    using Exceptions;
    using Extensions;
    using Headers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string request)
        {
            FormData = new Dictionary<string, object>();
            QueryData = new Dictionary<string, object>();
            Headers = new HttpHeaderCollection();

            this.ParseRequest(request);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string request)
        {
            string[] requestContent = request
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = requestContent[0]
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();
            this.ParseHeaders(requestContent.Skip(1).ToArray());
            this.ParseRequestParameters(requestContent.Last());
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            bool result = false;

            if (requestLine.Length == 3)
            {
                result = requestLine[2] == GlobalConstants.HttpOneProtocolFragment;
            }

            return result;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (Enum.TryParse(requestLine[0].Capitalize(), out HttpRequestMethod method))
            {
                this.RequestMethod = method;
            }
        }

        private void ParseRequestUrl(string[] requestLine)
            => this.Url = requestLine[1];

        private void ParseRequestPath()
            => this.Path = this.Url.Split('?')[0];

        private void ParseHeaders(string[] content)
        {
            if (!this.HasHost(content[0]))
            {
                throw new BadRequestException();
            }

            foreach (var line in content)
            {
                if (line == Environment.NewLine)
                {
                    return;
                }

                string[] headerContent = line.Split(':');
                HttpHeader header = new HttpHeader(headerContent[0].Trim(), headerContent[1].Trim());
                this.Headers.Add(header);
            }
        }

        private bool HasHost(string line)
            => line.Contains(GlobalConstants.HostHeaderKey);

        private void ParseRequestParameters(string line)
        {
            if (this.Url.Contains("?"))
            {
                this.ParseQueryParameters();
            }

            this.ParseFormDataParameters(line);
        }

        private void ParseQueryParameters()
        {
            string queryString = this.Url.Split('?')[1];

            if (IsValidRequestQueryString(queryString))
            {
                throw new BadRequestException();
            }

            this.ParseParameters(this.QueryData, queryString);
        }

        private void ParseFormDataParameters(string requestLine)
        {
            this.ParseParameters(this.FormData, requestLine);
        }

        private void ParseParameters(Dictionary<string, object> dictionary, string requestLine)
        {
            string[] parameters = requestLine.Split('&');
            foreach (var parameter in parameters)
            {
                string[] line = parameter.Split('=');
                dictionary.Add(line[0], TryParse(line[1]));
            }
        }

        private object TryParse(string value)
        {
            object result = value;
            if (int.TryParse(value, out int parsed))
            {
                result = parsed;
            }

            return result;
        }

        private bool IsValidRequestQueryString(string queryString)
            => string.IsNullOrWhiteSpace(queryString);
    }
}

