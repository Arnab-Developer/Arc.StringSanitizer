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
}