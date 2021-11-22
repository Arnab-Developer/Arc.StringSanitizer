using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest
{
    public class UnsanitizerWithSingleConfigTest
    {
        [Fact]
        public void CanUnsanitizeWithMultipleConfig()
        {
            string sanitizedString =
                "sample test with [sc]. some more [html space] char";

            SanitizerConfig config = new("special char", "[sc]");

            string unsanitizedString = sanitizedString.Unsanitize(config);

            Assert.Equal("sample test with special char. some more [html space] char", unsanitizedString);
        }

        [Fact]
        public void CanSkipUnsanitizeWithNotFoundString()
        {
            string sanitizedString =
                "sample test with [sc1]. some more [html space] char";

            SanitizerConfig config = new("special char", "[sc]");

            string unsanitizedString = sanitizedString.Unsanitize(config);

            Assert.Equal("sample test with [sc1]. some more [html space] char", unsanitizedString);
        }

        [Fact]
        public void CanUnsanitizeCheckNullInput()
        {
            string? sanitizedString = null;

            SanitizerConfig config = new("special char", "[sc]");

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                sanitizedString!.Unsanitize(config));

            Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
        }

        [Fact]
        public void CanUnsanitizeCheckEmptyInput()
        {
            string sanitizedString = string.Empty;

            SanitizerConfig config = new("special char", "[sc]");

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                sanitizedString.Unsanitize(config));

            Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
        }

        [Fact]
        public void CanUnsanitizeCheckBlankInput()
        {
            string sanitizedString = "";

            SanitizerConfig config = new("special char", "[sc]");

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                sanitizedString.Unsanitize(config));

            Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
        }

        [Fact]
        public void CanUnsanitizeCheckWhiteSpaceInput()
        {
            string sanitizedString = " ";

            SanitizerConfig config = new("special char", "[sc]");

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                sanitizedString.Unsanitize(config));

            Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
        }

        [Fact]
        public void CanUnsanitizeCheckNullConfig()
        {
            string sanitizedString =
                "sample test with special char. some more &nbsp; char";

            SanitizerConfig? config = null;

            Assert.Throws<NullReferenceException>(() => sanitizedString.Unsanitize(config!));
        }
    }
}
