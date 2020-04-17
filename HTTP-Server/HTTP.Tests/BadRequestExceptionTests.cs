namespace HTTP.Tests
{
    using Exceptions;
    using Xunit;

    public class BadRequestExceptionTests
    {
        [Fact]
        public void Throw_ShouldReturnMessage()
        {
            var message = "The Request was malformed or contains unsupported elements.";
            var error = new BadRequestException();

            Assert.Equal(message, error.Message);
        }
    }
}
