namespace HTTP.Tests
{
    using Extensions;
    using Xunit;

    public class StringExtensionsTests
    {
        [Fact]
        public void Capitalize_ShouldCapitalizeString()
        {
            var result = "hello".Capitalize();

            Assert.Equal("Hello", result);
        }

        [Fact]
        public void Capitalize_ShouldCapitalizeStrings()
        {
            var result = "Hello World".Capitalize();

            Assert.Equal("Hello World", result);
        }
    }
}
