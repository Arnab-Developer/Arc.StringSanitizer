namespace Arc.StringSanitizerTest;

public partial class StringSanitizerExtensionsTest
{
    [Fact]
    public void SanitizeSingle_SanitizeProperly_WhenStringFound()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        Assert.Equal("sample test with [sc]. some more &nbsp; char", sanitizedString);
    }

    [Fact]
    public void SanitizeSingle_DoNotSanitize_WhenStringNotFound()
    {
        // Arrange
        var unsanitizedString = "sample test with special 1char. some more &nbsp; char";

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        Assert.Equal("sample test with special 1char. some more &nbsp; char", sanitizedString);
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenInputIsNull()
    {
        // Arrange
        string? unsanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        string func() => unsanitizedString.Sanitize(_sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenInputIsEmpty()
    {
        // Arrange
        var unsanitizedString = "";

        // Act.
        string func() => unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenInputIsBlankSpace()
    {
        // Arrange
        var unsanitizedString = " ";

        // Act.
        string func() => unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenConfigIsNull()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        SanitizerConfig? sanitizerConfig = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        string func() => unsanitizedString.Sanitize(sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        Assert.Throws<NullReferenceException>(func);
    }
}