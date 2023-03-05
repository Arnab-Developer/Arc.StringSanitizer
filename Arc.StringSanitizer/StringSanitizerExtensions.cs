using System.Text;

namespace Arc.StringSanitizer;

/// <summary>
/// Extension methods for string sanitisation.
/// </summary>
public static class StringSanitizerExtensions
{
    /// <summary>
    /// This method takes a sanitizer config and based on that sanitize a string.
    /// </summary>
    public static string Sanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        var sanitizerConfigs = new List<SanitizerConfig>() { sanitizerConfig };
        return input.Sanitize(sanitizerConfigs);
    }

    /// <summary>
    /// This method takes multiple sanitizer configs and based on that sanitize a string.
    /// </summary>
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

    /// <summary>
    /// This method takes a sanitizer config and based on that unsanitize a string.
    /// </summary>
    public static string Unsanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        var sanitizerConfigs = new List<SanitizerConfig>() { sanitizerConfig };
        return input.Unsanitize(sanitizerConfigs);
    }

    /// <summary>
    /// This method takes multiple sanitizer configs and based on that unsanitize a string.
    /// </summary>
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