// Copyright (c) 2023, Arnab Roy Chowdhury and Contributors.
// All rights reserved. Licensed under the MIT License; see LICENSE.txt.

using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest;

public class UnsanitizerWithMultipleConfigTest
{
    [Fact]
    public void CanUnsanitizeWithMultipleConfig()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc]. some more [html space] char";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var unsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with special char. some more &nbsp; char", unsanitizedString);
    }

    [Fact]
    public void CanSkipUnsanitizeWithNotFoundString()
    {
        // Arrange.
        var sanitizedString = "sample test with [sc1]. some more [html space] char";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        string unsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with [sc1]. some more &nbsp; char", unsanitizedString);
    }

    [Fact]
    public void CanUnsanitizeCheckNullInput()
    {
        // Arrange.
        string? sanitizedString = null;

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => sanitizedString!.Unsanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckEmptyInput()
    {
        // Arrange.
        var sanitizedString = string.Empty;

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => sanitizedString.Unsanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckBlankInput()
    {
        // Arrange.
        var sanitizedString = "";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => sanitizedString.Unsanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckWhiteSpaceInput()
    {
        // Arrange.
        var sanitizedString = " ";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => sanitizedString.Unsanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanUnsanitizeCheckNullConfig()
    {
        // Arrange.
        var sanitizedString = "sample test with special char. some more &nbsp; char";
        List<SanitizerConfig>? sanitizerConfigs = null;

        // Act.
        var func = () => sanitizedString.Unsanitize(sanitizerConfigs!);

        // Assert.
        var ex = Assert.Throws<ArgumentNullException>(func);
        Assert.Equal("Value cannot be null. (Parameter 'sanitizerConfigs')", ex.Message);
    }
}