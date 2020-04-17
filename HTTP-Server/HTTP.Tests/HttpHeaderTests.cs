namespace HTTP.Tests
{
    using Headers;
    using Xunit;

    public class HttpHeaderTests
    {
        private readonly HttpHeader header;

        public HttpHeaderTests()
        {
            this.header = new HttpHeader("content-type", "application/json");
        }

        [Fact]
        public void Key_ShouldReturnHeaderKey()
        {
            var result = this.header.Key;

            Assert.Equal("content-type", result);
        }

        [Fact]
        public void Value_ShouldReturnHeaderValue()
        {
            var result = this.header.Value;

            Assert.Equal("application/json", result);
        }

        [Fact]
        public void ToString_ShouldReturnProperString()
        {
            var result = this.header.ToString();

            Assert.Equal("content-type: application/json", result);
        }
    }
}
