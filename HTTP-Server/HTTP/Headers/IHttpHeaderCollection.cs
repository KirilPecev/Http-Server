namespace HTTP.Headers
{
    public interface IHttpHeaderCollection
    {
        int Count { get; }

        void Add(HttpHeader header);

        bool ContainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
