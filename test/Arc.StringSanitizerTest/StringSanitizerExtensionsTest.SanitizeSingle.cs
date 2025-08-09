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
        sanitizedString.ShouldBe("sample test with [sc]. some more &nbsp; char");
    }

    [Fact]
    public void SanitizeSingle_DoNotSanitize_WhenStringNotFound()
    {
        // Arrange
        var unsanitizedString = "sample test with special 1char. some more &nbsp; char";

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        sanitizedString.ShouldBe("sample test with special 1char. some more &nbsp; char");
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenStringIsNull()
    {
        // Arrange
        string? unsanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => unsanitizedString.Sanitize(_sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenStringIsEmpty()
    {
        // Arrange
        var unsanitizedString = "";

        // Act.
        var func = () => unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenStringIsBlankSpace()
    {
        // Arrange
        var unsanitizedString = " ";

        // Act.
        var func = () => unsanitizedString.Sanitize(_sanitizerConfig);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void SanitizeSingle_ThrowException_WhenConfigIsNull()
    {
        // Arrange
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        SanitizerConfig? sanitizerConfig = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => unsanitizedString.Sanitize(sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        func.ShouldThrow<NullReferenceException>();
    }
}