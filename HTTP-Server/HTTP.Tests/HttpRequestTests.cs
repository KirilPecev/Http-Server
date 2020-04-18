namespace HTTP.Tests
{
    using Enums;
    using Requests;
    using System;
    using Exceptions;
    using Xunit;

    public class HttpRequestTests
    {
        private readonly string simpleGetRequest = @"GET /hello.html HTTP/1.1
User - Agent: Mozilla / 4.0(compatible; MSIE5.01; Windows NT)
Host: www.tutorialspoint.com
Accept - Language: en - us
Accept - Encoding: gzip, deflate
Connection: Keep - Alive" + Environment.NewLine;

        private readonly string getRequestWithQueryData = @"GET /hello.html?id=1&name=Kiril HTTP/1.1
User - Agent: Mozilla / 4.0(compatible; MSIE5.01; Windows NT)
Host: www.tutorialspoint.com
Accept - Language: en - us
Accept - Encoding: gzip, deflate
Connection: Keep - Alive" + Environment.NewLine;

        private readonly string postRequestWithFormData = @"POST /cgi-bin/process.cgi HTTP/1.1
User-Agent: Mozilla/4.0 (compatible; MSIE5.01; Windows NT)
Host: www.tutorialspoint.com
Content-Type: application/x-www-form-urlencoded
Content-Length: length
Accept-Language: en-us
Accept-Encoding: gzip, deflate
Connection: Keep-Alive

licenseID=string&content=string&/paramsXML=string";

        private readonly string invalidSimpleGetRequest = @"GET /hello.html HTTP/1.1
User - Agent: Mozilla / 4.0(compatible; MSIE5.01; Windows NT)
Accept - Language: en - us
Accept - Encoding: gzip, deflate
Connection: Keep - Alive" + Environment.NewLine;


        private readonly string invalidGetRequest = @"GET /hello.html? HTTP/1.1
User - Agent: Mozilla / 4.0(compatible; MSIE5.01; Windows NT)
Host: www.tutorialspoint.com
Accept - Language: en - us
Accept - Encoding: gzip, deflate
Connection: Keep - Alive" + Environment.NewLine;

        private readonly string invalidGetRequestHttpProtocol = @"GET /hello.html? HTTP/3.1
User - Agent: Mozilla / 4.0(compatible; MSIE5.01; Windows NT)
Host: www.tutorialspoint.com
Accept - Language: en - us
Accept - Encoding: gzip, deflate
Connection: Keep - Alive" + Environment.NewLine;

        private readonly HttpRequest httpRequestSimpleGetRequest;
        private readonly HttpRequest httpRequestGetRequestWithQueryData;
        private readonly HttpRequest httpRequestPostRequestWithFormData;

        public HttpRequestTests()
        {
            this.httpRequestSimpleGetRequest = new HttpRequest(simpleGetRequest);
            this.httpRequestGetRequestWithQueryData = new HttpRequest(getRequestWithQueryData);
            this.httpRequestPostRequestWithFormData = new HttpRequest(postRequestWithFormData);
        }

        [Fact]
        public void Path_ShouldReturnCorrectPath()
        {
            string expected = "/hello.html";
            string actual = this.httpRequestSimpleGetRequest.Path;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Url_ShouldReturnCorrectUrl()
        {
            string expected = "/hello.html";
            string actual = this.httpRequestSimpleGetRequest.Url;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormData_ShouldBeEmpty()
        {
            int expected = 0;
            int actual = this.httpRequestSimpleGetRequest.FormData.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueryData_ShouldBeEmpty()
        {
            int expected = 0;
            int actual = this.httpRequestSimpleGetRequest.QueryData.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Headers_ShouldHave5Headers()
        {
            int expected = 5;
            int actual = this.httpRequestSimpleGetRequest.Headers.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestMethod_ShouldBeGet()
        {
            HttpRequestMethod expected = HttpRequestMethod.Get;
            HttpRequestMethod actual = this.httpRequestSimpleGetRequest.RequestMethod;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Path_ShouldReturnCorrectPathWithoutQueryParameters()
        {
            string expected = "/hello.html";
            string actual = this.httpRequestGetRequestWithQueryData.Path;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Url_ShouldReturnCorrectUrlWithQueryParameters()
        {
            string expected = "/hello.html?id=1&name=Kiril";
            string actual = this.httpRequestGetRequestWithQueryData.Url;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void QueryData_ShouldHave2Parameters()
        {
            int expected = 2;
            int actual = this.httpRequestGetRequestWithQueryData.QueryData.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RequestMethod_ShouldBePost()
        {
            HttpRequestMethod expected = HttpRequestMethod.Post;
            HttpRequestMethod actual = this.httpRequestPostRequestWithFormData.RequestMethod;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormData_ShouldHave2Parameters()
        {
            int expected = 3;
            int actual = this.httpRequestPostRequestWithFormData.FormData.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HttpRequest_ShouldThrowBadRequestError()
        {
            Assert.Throws<BadRequestException>(() => new HttpRequest(invalidSimpleGetRequest));
        }

        [Fact]
        public void HttpRequestWithInvalidQueryParams_ShouldThrowBadRequestError()
        {
            Assert.Throws<BadRequestException>(() => new HttpRequest(invalidGetRequest));
        }


        [Fact]
        public void HttpRequestWithInvalidHttpProtocol_ShouldThrowBadRequestError()
        {
            Assert.Throws<BadRequestException>(() => new HttpRequest(invalidGetRequestHttpProtocol));
        }
    }
}
