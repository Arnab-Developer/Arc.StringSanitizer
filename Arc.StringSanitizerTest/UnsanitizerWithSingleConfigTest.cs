using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest;

public class UnsanitizerWithSingleConfigTest
{
    [Fact]
    public void CanUnsanitizeWithMultipleConfig()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(config);

        // Assert.
        Assert.Equal("sample test with special char. some more [html space] char", unsanitizedString);
    }

    [Fact]
    public void CanSkipUnsanitizeWithNotFoundString()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc1]. some more [html space] char";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(config);

        // Assert.
        Assert.Equal("sample test with [sc1]. some more [html space] char", unsanitizedString);
    }

    [Fact]
    public void CanUnsanitizeCheckNullInput()
    {
        // Arrange.
        string? sanitizedString = null;
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => sanitizedString!.Unsanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckEmptyInput()
    {
        // Arrange.
        var sanitizedString = string.Empty;
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => sanitizedString.Unsanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckBlankInput()
    {
        // Arrange.
        var sanitizedString = "";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => sanitizedString.Unsanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckWhiteSpaceInput()
    {
        // Arrange.
        var sanitizedString = " ";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => sanitizedString.Unsanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckNullConfig()
    {
        // Arrange.
        var sanitizedString = "sample test with special char. some more &nbsp; char";
        SanitizerConfig? config = null;

        // Act.
        var func = () => sanitizedString.Unsanitize(config!);

        // Assert.
        Assert.Throws<NullReferenceException>(func);
    }
}