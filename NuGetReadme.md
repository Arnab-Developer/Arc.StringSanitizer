# String sanitizer

This library is to sanitize and unsanitize string. It is created with .NET 5 and Visual Studo 2019.

Suppose you are working on a string and there are some special chars in it
for that you can't work with that string. Then you need to replace those 
special chars to anything simple chars with which you can work with the string. Also when
you are done then you may need to revert them to get back to the previous state of the string.

This library helps you to do that. You can create a config with details like which special chars
need to be replaced with which simple chars and call the sanitize method. When your
work with the string will complete then you can revert all the sanitization by
calling the unsanitize method of this library.

Install the library in your project with below command:

```
dotnet add package Arc.StringSanitizer
```

To sanitize a string:

```csharp
string unsanitizedString =
    "sample test with special char. some more &nbsp; char";

List<SanitizerConfig> sanitizerConfigs = new()
{
    new SanitizerConfig("special char", "[sc]"),
    new SanitizerConfig("&nbsp;", "[html space]")
};

string sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);

Console.WriteLine(sanitizedString);

// Output: sample test with [sc]. some more [html space] char
```

To unsanitize a string:

```csharp
string sanitizedString =
    "sample test with [sc]. some more [html space] char";

List<SanitizerConfig> sanitizerConfigs = new()
{
    new SanitizerConfig("special char", "[sc]"),
    new SanitizerConfig("&nbsp;", "[html space]")
};

string unsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);

Console.WriteLine(unsanitizedString);

// Output: sample test with special char. some more &nbsp; char
```
