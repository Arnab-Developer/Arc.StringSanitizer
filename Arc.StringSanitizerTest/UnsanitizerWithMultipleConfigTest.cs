using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest;

public class UnsanitizerWithMultipleConfigTest
{
    [Fact]
    public void CanUnsanitizeWithMultipleConfig()
    {
        string sanitizedString =
            "sample test with [sc]. some more [html space] char";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        string unsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);

        Assert.Equal("sample test with special char. some more &nbsp; char", unsanitizedString);
    }

    [Fact]
    public void CanSkipUnsanitizeWithNotFoundString()
    {
        string sanitizedString =
            "sample test with [sc1]. some more [html space] char";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        string unsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);

        Assert.Equal("sample test with [sc1]. some more &nbsp; char", unsanitizedString);
    }

    [Fact]
    public void CanUnsanitizeCheckNullInput()
    {
        string? sanitizedString = null;

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            sanitizedString!.Unsanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckEmptyInput()
    {
        string sanitizedString = string.Empty;

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            sanitizedString.Unsanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckBlankInput()
    {
        string sanitizedString = "";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            sanitizedString.Unsanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckWhiteSpaceInput()
    {
        string sanitizedString = " ";

        List<SanitizerConfig> sanitizerConfigs = new()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            sanitizedString.Unsanitize(sanitizerConfigs));

        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckNullConfig()
    {
        string sanitizedString =
            "sample test with special char. some more &nbsp; char";

        List<SanitizerConfig>? sanitizerConfigs = null;

        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            sanitizedString.Unsanitize(sanitizerConfigs!));

        Assert.Equal("Value cannot be null. (Parameter 'sanitizerConfigs')", ex.Message);
    }
}