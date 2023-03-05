# String sanitizer

This library is to sanitize and unsanitize string.

Suppose you are working on a string and there are some special chars in it for that you can't work with that string. Then you need to replace those special chars to anything simple chars with which you can work with the string. Also when you are done then you may need to revert them to get back to the previous state of the string.

This library helps you to do that. You can create a config with details like which special chars need to be replaced with which simple chars and call the sanitize method. When your work with the string will complete then you can revert all the sanitization by calling the unsanitize method of this library.

## How to use

To sanitize a string:

```csharp
var unsanitizedString = "sample test with special char. some more &nbsp; char";

var sanitizerConfigs = new List<SanitizerConfig>()
{
    new SanitizerConfig("special char", "[sc]"),
    new SanitizerConfig("&nbsp;", "[html space]")
};

var sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);
Console.WriteLine(sanitizedString);

// Output: sample test with [sc]. some more [html space] char
```

To unsanitize a string:

```csharp
var sanitizedString = "sample test with [sc]. some more [html space] char";

var sanitizerConfigs = new List<SanitizerConfig>()
{
    new SanitizerConfig("special char", "[sc]"),
    new SanitizerConfig("&nbsp;", "[html space]")
};

var unsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);
Console.WriteLine(unsanitizedString);

// Output: sample test with special char. some more &nbsp; char
```