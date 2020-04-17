namespace HTTP.Tests
{
    using Enums;
    using Extensions;
    using Xunit;

    public class HttpResponseStatusExtensionsTests
    {
        [Fact]
        public void GetResponseLine_ShouldReturnResponseLineOK()
        {
            var result = "200 OK";
            var response = HttpResponseStatusCode.Ok.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseLineInternalServerError()
        {
            var result = "500 Internal Server Error";
            var response = HttpResponseStatusCode.InternalServerError.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseLineCreated()
        {
            var result = "201 Created";
            var response = HttpResponseStatusCode.Created.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseLineFound()
        {
            var result = "302 Found";
            var response = HttpResponseStatusCode.Found.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseLineSeeOther()
        {
            var result = "303 See Other";
            var response = HttpResponseStatusCode.SeeOther.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseLineBadRequest()
        {
            var result = "400 Bad Request";
            var response = HttpResponseStatusCode.BadRequest.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnUnauthorized()
        {
            var result = "401 Unauthorized";
            var response = HttpResponseStatusCode.Unauthorized.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseForbidden()
        {
            var result = "403 Forbidden";
            var response = HttpResponseStatusCode.Forbidden.GetResponseLine();

            Assert.Equal(result, response);
        }

        [Fact]
        public void GetResponseLine_ShouldReturnResponseNotFound()
        {
            var result = "404 Not Found";
            var response = HttpResponseStatusCode.NotFound.GetResponseLine();

            Assert.Equal(result, response);
        }
    }
}
