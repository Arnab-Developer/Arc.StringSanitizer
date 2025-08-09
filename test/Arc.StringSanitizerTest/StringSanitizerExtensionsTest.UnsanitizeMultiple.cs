namespace Arc.StringSanitizerTest;

public partial class StringSanitizerExtensionsTest
{
    [Fact]
    public void UnsanitizeMultiple_UnsanitizeProperly_WhenSringIsFound()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(_sanitizerConfigs);

        // Assert.
        unsanitizedString.ShouldBe("sample test with special char. some more &nbsp; char");
    }

    [Fact]
    public void UnsanitizeMultiple_DoNotUnsanitize_WhenSringIsNotFound()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc1]. some more [html space] char";

        // Act.
        string unsanitizedString = sanitizedString.Unsanitize(_sanitizerConfigs);

        // Assert.
        unsanitizedString.ShouldBe("sample test with [sc1]. some more &nbsp; char");
    }

    [Fact]
    public void UnsanitizeMultiple_ThrowException_WhenSringIsNull()
    {
        // Arrange.
        string? sanitizedString = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => sanitizedString.Unsanitize(_sanitizerConfigs);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void UnsanitizeMultiple_ThrowException_WhenSringIsEmpty()
    {
        // Arrange.
        var sanitizedString = "";

        // Act.
        var func = () => sanitizedString.Unsanitize(_sanitizerConfigs);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void UnsanitizeMultiple_ThrowException_WhenSringIsBlankSpace()
    {
        // Arrange.
        var sanitizedString = " ";

        // Act.
        var func = () => sanitizedString.Unsanitize(_sanitizerConfigs);

        // Assert.
        var ex = func.ShouldThrow<ArgumentException>();
        ex.Message.ShouldBe("'input' cannot be null or empty. (Parameter 'input')");
    }

    [Fact]
    public void UnsanitizeMultiple_ThrowException_WhenConfigsAreNull()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";
        List<SanitizerConfig>? sanitizerConfigs = null;

        // Act.
#pragma warning disable CS8604 // Possible null reference argument.
        var func = () => sanitizedString.Unsanitize(sanitizerConfigs);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert.
        func.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void UnsanitizeMultiple_DoNotUnsanitize_WhenConfigsAreEmpty()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";
        _sanitizerConfigs.Clear();

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(_sanitizerConfigs);

        // Assert.
        unsanitizedString.ShouldBe("sample test with [sc]. some more [html space] char");
    }
}