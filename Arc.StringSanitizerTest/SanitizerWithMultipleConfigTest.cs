// Copyright (c) 2023, Arnab Roy Chowdhury and Contributors.
// All rights reserved. Licensed under the MIT License; see LICENSE.txt.

using Arc.StringSanitizer;
using Xunit;

namespace Arc.StringSanitizerTest;

public class SanitizerWithMultipleConfigTest
{
    [Fact]
    public void CanSanitizeWithMultipleConfig()
    {
        // Arrange.
        var unsanitizedString = "sample test with special char. some more &nbsp; char";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with [sc]. some more [html space] char", sanitizedString);
    }

    [Fact]
    public void CanSkipSanitizeWithNotFoundString()
    {
        // Arrange.
        var unsanitizedString = "sample test with special char. some more &nbsp char";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);

        // Assert.
        Assert.Equal("sample test with [sc]. some more &nbsp char", sanitizedString);
    }

    [Fact]
    public void CanSanitizeCheckNullInput()
    {
        // Arrange.
        string? unsanitizedString = null;

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => unsanitizedString!.Sanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckEmptyInput()
    {
        // Arrange.
        var unsanitizedString = string.Empty;

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => unsanitizedString.Sanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckBlankInput()
    {
        // Arrange.
        var unsanitizedString = "";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => unsanitizedString.Sanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckWhiteSpaceInput()
    {
        // Arrange.
        var unsanitizedString = " ";

        var sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };

        // Act.
        var func = () => unsanitizedString.Sanitize(sanitizerConfigs);

        // Assert.
        var ex = Assert.Throws<ArgumentException>(func);
        Assert.Equal("'input' cannot be null or empty. (Parameter 'input')", ex.Message);
    }

    [Fact]
    public void CanSanitizeCheckNullConfig()
    {
        // Arrange.
        var unsanitizedString = "sample test with special char. some more &nbsp; char";
        List<SanitizerConfig>? sanitizerConfigs = null;

        // Act.
        var func = () => unsanitizedString.Sanitize(sanitizerConfigs!);

        // Assert.
        var ex = Assert.Throws<ArgumentNullException>(func);
        Assert.Equal("Value cannot be null. (Parameter 'sanitizerConfigs')", ex.Message);
    }
}