namespace HTTP.Tests
{
    using System.Linq;
    using Common;
    using Enums;
    using Extensions;
    using Headers;
    using Responses;
    using System.Text;
    using Xunit;

    public class HttpResponseTests
    {
        public readonly HttpResponse HttpResponse;

        public HttpResponseTests()
        {
            this.HttpResponse = new HttpResponse(HttpResponseStatusCode.Ok);
            this.AddHeaders();
        }

        [Fact]
        public void AddHeader_ShouldAddHeader()
        {
            HttpHeader header = this.HttpResponse.Headers.GetHeader("connection");

            Assert.NotNull(header);
        }

        [Fact]
        public void ToString_ShouldReturnWellFormattedString()
        {
            string expected = @$"{GlobalConstants.HttpOneProtocolFragment} {HttpResponseStatusCode.Ok.GetResponseLine()}
connection: keep-alive
content-length: 100

";
            string actual = this.HttpResponse.ToString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetBytes_ShouldReturnResponseInBytesWithoutContent()
        {
            byte[] expected = Encoding.ASCII.GetBytes(this.HttpResponse.ToString());
            byte[] actual = this.HttpResponse.GetBytes();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetBytes_ShouldReturnResponseInBytesWithContent()
        {
            this.HttpResponse.Content = Encoding.ASCII.GetBytes("some big beauty picture");

            byte[] expected = Encoding.ASCII.GetBytes(this.HttpResponse.ToString())
                .Concat(this.HttpResponse.Content)
                .ToArray();
            
            byte[] actual = this.HttpResponse.GetBytes();

            Assert.Equal(expected, actual);
        }

        private void AddHeaders()
        {
            HttpHeader firstHeader = new HttpHeader("connection", "keep-alive");
            this.HttpResponse.AddHeader(firstHeader);
            HttpHeader secondHeader = new HttpHeader("content-length", "100");
            this.HttpResponse.AddHeader(secondHeader);
        }
    }
}
