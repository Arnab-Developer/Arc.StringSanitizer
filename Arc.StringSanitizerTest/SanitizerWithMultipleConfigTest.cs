using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest;

public class SanitizerWithMultipleConfigTest
{
    [Fact]
    public void CanSanitizeWithMultipleConfig()
    {
        string unsanitizedString =
            "sample test with special char. some more &nbsp; char";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        string sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);

        Assert.Equal("sample test with [sc]. some more [html space] char", sanitizedString);
    }

    [Fact]
    public void CanSkipSanitizeWithNotFoundString()
    {
        string unsanitizedString =
            "sample test with special char. some more &nbsp char";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        string sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);

        Assert.Equal("sample test with [sc]. some more &nbsp char", sanitizedString);
    }

    [Fact]
    public void CanSanitizeCheckNullInput()
    {
        string? unsanitizedString = null;

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString!.Sanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckEmptyInput()
    {
        string unsanitizedString = string.Empty;

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString.Sanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckBlankInput()
    {
        string unsanitizedString = "";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString.Sanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckWhiteSpaceInput()
    {
        string unsanitizedString = " ";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            unsanitizedString.Sanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckNullConfig()
    {
        string unsanitizedString =
            "sample test with special char. some more &nbsp; char";

        List<SanitizerConfig>? sanitizerConfigs = null;

        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            unsanitizedString.Sanitize(sanitizerConfigs!));

        Assert.Equal("Value cannot be null. (Parameter 'sanitizerConfigs')", ex.Message);
    }
}