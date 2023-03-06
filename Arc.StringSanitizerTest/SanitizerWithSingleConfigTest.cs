namespace Arc.StringSanitizerTest;

public class SanitizerWithSingleConfigTest
{
    [Fact]
    public void CanSanitizeWithSingleConfig()
    {
        // Arrange.
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(config);

        // Assert.
        Assert.Equal("sample test with [sc]. some more &nbsp; char", sanitizedString);
    }

    [Fact]
    public void CanSkipSanitizeWithNotFoundString()
    {
        // Arrange.
        var unsanitizedString = "sample test with special 1char. some more &nbsp; char";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(config);

        // Assert.
        Assert.Equal("sample test with special 1char. some more &nbsp; char", sanitizedString);
    }

    [Fact]
    public void CanSanitizeCheckNullInput()
    {
        // Arrange.
        string? unsanitizedString = null;
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => unsanitizedString!.Sanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckEmptyInput()
    {
        // Arrange.
        var unsanitizedString = string.Empty;
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => unsanitizedString!.Sanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckBlankInput()
    {
        // Arrange.
        var unsanitizedString = "";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => unsanitizedString!.Sanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckWhiteSpaceInput()
    {
        // Arrange.
        var unsanitizedString = " ";
        var config = new SanitizerConfig("special char", "[sc]");

        // Act.
        var func = () => unsanitizedString!.Sanitize(config);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckNullConfig()
    {
        // Arrange.
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        SanitizerConfig? config = null;

        // Act.
        var func = () => unsanitizedString!.Sanitize(config!);

        // Assert.
        Assert.Throws<NullReferenceException>(func);
    }
}