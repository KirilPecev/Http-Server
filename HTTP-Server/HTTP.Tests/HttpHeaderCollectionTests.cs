namespace HTTP.Tests
{
    using Headers;
    using Xunit;

    public class HttpHeaderCollectionTests
    {
        private readonly HttpHeaderCollection collection;
        private readonly HttpHeader header;


        public HttpHeaderCollectionTests()
        {
            this.collection = new HttpHeaderCollection();
            this.header = this.header = new HttpHeader("content-type", "application/json");
        }

        [Fact]
        public void Add_ShouldAddHeader()
        {
            string errorMessage = "HttpHeaderCollection Add() method does not add header!";
            this.collection.Add(this.header);

            Assert.True(this.collection.ContainsHeader("content-type"), errorMessage);
        }

        [Fact]
        public void GetHeader_ShouldGetHeader()
        {
            this.collection.Add(this.header);
            HttpHeader result = this.collection.GetHeader("content-type");
            
            Assert.NotNull(result);
        }
    }
}
