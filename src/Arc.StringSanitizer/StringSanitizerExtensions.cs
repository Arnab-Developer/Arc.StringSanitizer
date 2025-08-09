using System.Text;

namespace Arc.StringSanitizer;

/// <include file='XmlDocs/StringSanitizerExtensions.xml' path='docs/StringSanitizerExtensions/*'/>
public static class StringSanitizerExtensions
{
    /// <include file='XmlDocs/StringSanitizerExtensions.xml' path='docs/SanitizeSingle/*'/>
    public static string Sanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        var sanitizerConfigs = new List<SanitizerConfig>() { sanitizerConfig };
        return input.Sanitize(sanitizerConfigs);
    }

    /// <include file='XmlDocs/StringSanitizerExtensions.xml' path='docs/SanitizeMany/*'/>
    public static string Sanitize(this string input, IEnumerable<SanitizerConfig> sanitizerConfigs)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"'{nameof(input)}' cannot be null or empty.", nameof(input));
        }

        if (sanitizerConfigs is null)
        {
            throw new ArgumentNullException(nameof(sanitizerConfigs));
        }

        var sb = new StringBuilder(input);

        foreach (SanitizerConfig sanitizerConfig in sanitizerConfigs)
        {
            sb.Replace(sanitizerConfig.From, sanitizerConfig.To);
        }

        return sb.ToString();
    }

    /// <include file='XmlDocs/StringSanitizerExtensions.xml' path='docs/UnsanitizeSingle/*'/>
    public static string Unsanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        var sanitizerConfigs = new List<SanitizerConfig>() { sanitizerConfig };
        return input.Unsanitize(sanitizerConfigs);
    }

    /// <include file='XmlDocs/StringSanitizerExtensions.xml' path='docs/UnsanitizeMany/*'/>
    public static string Unsanitize(this string input, IEnumerable<SanitizerConfig> sanitizerConfigs)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"'{nameof(input)}' cannot be null or empty.", nameof(input));
        }

        if (sanitizerConfigs is null)
        {
            throw new ArgumentNullException(nameof(sanitizerConfigs));
        }

        var reverseSanitizerConfigs = sanitizerConfigs
            .Select(sanitizerConfig => new SanitizerConfig(sanitizerConfig.To, sanitizerConfig.From));

        return input.Sanitize(reverseSanitizerConfigs);
    }
}