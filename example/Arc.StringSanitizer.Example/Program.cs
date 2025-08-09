using Arc.StringSanitizer;
using static System.Console;

var unsanitizedString = "sample test with special char. some more &nbsp; char";

var sanitizerConfigs = new List<SanitizerConfig>()
{
    new SanitizerConfig("special char", "[sc]"),
    new SanitizerConfig("&nbsp;", "[html space]")
};

var sanitizedString = unsanitizedString.Sanitize(sanitizerConfigs);
WriteLine(sanitizedString); // Output: sample test with [sc]. some more [html space] char

var newUnsanitizedString = sanitizedString.Unsanitize(sanitizerConfigs);
WriteLine(newUnsanitizedString); // Output: sample test with special char. some more &nbsp; char