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
        sanitizedString.ShouldBe("sample test with [sc]. some more [html space] char");
    }

    [Fact]
    public void SanitizeMultiple_DoNotSanitize_WhenStringNotFound()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp char";

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        sanitizedString.ShouldBe("sample test with [sc]. some more &nbsp char");
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenStringIsNull()
    {
        // Arrange
        string? unsanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => unsanitizedString.Sanitize(_sanitizerConfigs);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenStringIsEmpty()
    {
        // Arrange
        var unsanitizedString = "";

        // Act.
        var func = () => unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenStringIsBlankSpace()
    {
        // Arrange
        var unsanitizedString = " ";

        // Act.
        var func = () => unsanitizedString.Sanitize(_sanitizerConfigs);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void SanitizeMultiple_ThrowException_WhenConfigsAreNull()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        List<SanitizerConfig>? sanitizerConfigs = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => unsanitizedString.Sanitize(sanitizerConfigs);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = func.ShouldThrow<ArgumentNullException>();
        ex.Message.ShouldBe("Value cannot be null. (Parameter 'sanitizerConfigs')");
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
        sanitizedString.ShouldBe("sample test with special char. some more &nbsp; char");
    }
}