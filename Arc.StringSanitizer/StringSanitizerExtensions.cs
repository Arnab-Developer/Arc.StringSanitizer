using System.Text;

namespace Arc.StringSanitizer;

/// <summary>
/// Extension methods for string sanitisation.
/// </summary>
public static class StringSanitizerExtensions
{
    /// <summary>
    /// Sanitize a string.
    /// </summary>
    /// <param name="input">Unsanitized string.</param>
    /// <param name="sanitizerConfig">Sanitizer config.</param>
    /// <returns></returns>
    public static string Sanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        IEnumerable<SanitizerConfig> sanitizerConfigs = new List<SanitizerConfig>()
            {
                sanitizerConfig
            };
        return input.Sanitize(sanitizerConfigs);
    }

    /// <summary>
    /// Sanitize a string.
    /// </summary>
    /// <param name="input">Unsanitized string.</param>
    /// <param name="sanitizerConfigs">Sanitizer configs.</param>
    /// <returns></returns>
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

        StringBuilder sb = new(input);
        foreach (SanitizerConfig sanitizerConfig in sanitizerConfigs)
        {
            sb.Replace(sanitizerConfig.From, sanitizerConfig.To);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Unsanitize a string.
    /// </summary>
    /// <param name="input">Sanitized string.</param>
    /// <param name="sanitizerConfig">Sanitizer config.</param>
    /// <returns></returns>
    public static string Unsanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        IEnumerable<SanitizerConfig> sanitizerConfigs = new List<SanitizerConfig>()
            {
                sanitizerConfig
            };
        return input.Unsanitize(sanitizerConfigs);
    }

    /// <summary>
    /// Unsanitize a string.
    /// </summary>
    /// <param name="input">Sanitized string.</param>
    /// <param name="sanitizerConfigs">Sanitizer configs.</param>
    /// <returns></returns>
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

        IEnumerable<SanitizerConfig> reverseSanitizerConfigs
            = from sanitizerConfig in sanitizerConfigs
              select new SanitizerConfig(sanitizerConfig.To, sanitizerConfig.From);

        return input.Sanitize(reverseSanitizerConfigs);
    }
}