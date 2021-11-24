using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest;

public class SanitizerWithSingleConfigTest
{
    [Fact]
    public void CanSanitizeWithSingleConfig()
    {
        string unsanitizedString =
            "sample test with special char. some more &nbsp; char";

        SanitizerConfig config = new("special char", "[sc]");

        string sanitizedString = unsanitizedString.Sanitize(config);

        Assert.Equal("sample test with [sc]. some more &nbsp; char", sanitizedString);
    }

    [Fact]
    public void CanSkipSanitizeWithNotFoundString()
    {
        string unsanitizedString =
            "sample test with special 1char. some more &nbsp; char";

        SanitizerConfig config = new("special char", "[sc]");

        string sanitizedString = unsanitizedString.Sanitize(config);

        Assert.Equal("sample test with special 1char. some more &nbsp; char", sanitizedString);
    }

    [Fact]
    public void CanSanitizeCheckNullInput()
    {
        string? unsanitizedString = null;

        SanitizerConfig config = new("special char", "[sc]");

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString!.Sanitize(config));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckEmptyInput()
    {
        string unsanitizedString = string.Empty;

        SanitizerConfig config = new("special char", "[sc]");

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString.Sanitize(config));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckBlankInput()
    {
        string unsanitizedString = "";

        SanitizerConfig config = new("special char", "[sc]");

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString.Sanitize(config));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckWhiteSpaceInput()
    {
        string unsanitizedString = " ";

        SanitizerConfig config = new("special char", "[sc]");

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString.Sanitize(config));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckNullConfig()
    {
        string unsanitizedString =
            "sample test with special char. some more &nbsp; char";

        SanitizerConfig? sanitizerConfigs = null;

        Assert.Throws<NullReferenceException>(() => unsanitizedString.Sanitize(sanitizerConfigs!));
    }
}