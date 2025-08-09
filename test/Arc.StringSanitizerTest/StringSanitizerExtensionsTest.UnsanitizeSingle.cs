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
        Assert.Equal("sample test with special char. some more [html space] char", unsanitizedString);
    }

    [Fact]
    public void UnsanitizeSingle_DoNotUnsanitize_WhenStringIsNotFound()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc1]. some more [html space] char";

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        Assert.Equal("sample test with [sc1]. some more [html space] char", unsanitizedString);
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenStringIsNull()
    {
        // Arrange.
        string? sanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        string func() => sanitizedString.Unsanitize(_sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenStringIsEmpty()
    {
        // Arrange.
        var sanitizedString = "";

        // Act.
        string func() => sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenStringIsBlankSpace()
    {
        // Arrange.
        var sanitizedString = " ";

        // Act.
        string func() => sanitizedString.Unsanitize(_sanitizerConfig);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void UnsanitizeSingle_ThrowException_WhenConfigIsNull()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";
        SanitizerConfig? sanitizerConfig = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        string func() => sanitizedString.Unsanitize(sanitizerConfig);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        Assert.Throws<NullReferenceException>(func);
    }
}