namespace Arc.StringSanitizerTest;

public partial class StringSanitizerExtensionsTest
{
    [Fact]
    public void SanitizeMultiple_SanitizeProperly_WhenStringFound()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with [sc]. some more [html space] char", sanitizedString);
    }

    [Fact]
    public void SanitizeMultiple_DoNotSanitize_WhenStringNotFound()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp char";

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with [sc]. some more &nbsp char", sanitizedString);
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenStringIsNull()
    {
        // Arrange
        string? unsanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        string func() => unsanitizedString.Sanitize(_sanitizerConfigs);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenStringIsEmpty()
    {
        // Arrange
        var unsanitizedString = "";

        // Act.
        string func() => unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenStringIsBlankSpace()
    {
        // Arrange
        var unsanitizedString = " ";

        // Act.
        string func() => unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenConfigsAreNull()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        List<SanitizerConfig>? sanitizerConfigs = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        string func() => unsanitizedString.Sanitize(sanitizerConfigs);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = Assert.Throws<ArgumentNullException>(func);
        Assert.Equal("Value cannot be null. (Parameter 'sanitizerConfigs')", ex.Message);
    }

    [Fact]
    public void SanitizeMultiple_DoNotSanitize_WhenConfigsAreEmpty()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        _sanitizerConfigs.Clear();

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with special char. some more &nbsp; char", sanitizedString);
    }
}