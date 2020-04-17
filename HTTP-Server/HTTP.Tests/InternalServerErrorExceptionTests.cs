namespace HTTP.Tests
{
    using Exceptions;
    using Xunit;

    public class InternalServerErrorExceptionTests
    {
        [Fact]
        public void Throw_ShouldReturnMessage()
        {
            var message = "The Server has encountered an error.";
            var error = new InternalServerErrorException();

            Assert.Equal(message, error.Message);
        }
    }
}
