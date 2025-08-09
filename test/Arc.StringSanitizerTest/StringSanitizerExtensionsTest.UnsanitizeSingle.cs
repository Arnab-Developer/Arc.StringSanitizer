namespace Arc.StringSanitizerTest;

public partial class StringSanitizerExtensionsTest
{
    [Fact]
    public void UnsanitizeSingle_UnsanitizeProperly_WhenStringIsFound()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        unsanitizedString.ShouldBe("sample test with special char. some more [html space] char");
    }

    [Fact]
    public void UnsanitizeSingle_DoNotUnsanitize_WhenStringIsNotFound()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc1]. some more [html space] char";

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        unsanitizedString.ShouldBe("sample test with [sc1]. some more [html space] char");
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenStringIsNull()
    {
        // Arrange.
        string? sanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => sanitizedString.Unsanitize(_sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenStringIsEmpty()
    {
        // Arrange.
        var sanitizedString = "";

        // Act.
        var func = () => sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenStringIsBlankSpace()
    {
        // Arrange.
        var sanitizedString = " ";

        // Act.
        var func = () => sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenConfigIsNull()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";
        SanitizerConfig? sanitizerConfig = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => sanitizedString.Unsanitize(sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        func.ShouldThrow<NullReferenceException>();
    }
}