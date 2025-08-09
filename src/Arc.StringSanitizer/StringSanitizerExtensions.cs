using System.Text;

namespace Arc.StringSanitizer;

/// <summary>Extension methods for string sanitisation.</summary>
public static class StringSanitizerExtensions
{
    /// <summary>This method takes a sanitizer config and based on that sanitize a string.</summary>
    /// <param name="input">Unsanitized string.</param>
    /// <param name="sanitizerConfig">Sanitizer configuration.</param>
    /// <returns>Sanitized string.</returns>
    /// <exception cref="ArgumentException">It throws ArgumentException when input string is null or empty.</exception>
    /// <exception cref="ArgumentNullException">It throws ArgumentNullException when input config is null.</exception>
    public static string Sanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        var sanitizerConfigs = new List<SanitizerConfig>() { sanitizerConfig };
        return input.Sanitize(sanitizerConfigs);
    }

    /// <summary>This method takes multiple sanitizer configs and based on that sanitize a string.</summary>
    /// <param name="input">Unsanitized string.</param>
    /// <param name="sanitizerConfigs">Multiple sanitizer configurations.</param>
    /// <returns>Sanitized string.</returns>
    /// <exception cref="ArgumentException">It throws ArgumentException when input string is null or empty.</exception>
    /// <exception cref="ArgumentNullException">It throws ArgumentNullException when input config is null.</exception>
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

    /// <summary>This method takes a sanitizer config and based on that unsanitize a string.</summary>
    /// <param name="input">Sanitized string.</param>
    /// <param name="sanitizerConfig">Sanitizer configuration.</param>
    /// <returns>Unsanitized string.</returns>
    /// <exception cref="ArgumentException">It throws ArgumentException when input string is null or empty.</exception>
    /// <exception cref="ArgumentNullException">It throws ArgumentNullException when input config is null.</exception>
    public static string Unsanitize(this string input, SanitizerConfig sanitizerConfig)
    {
        var sanitizerConfigs = new List<SanitizerConfig>() { sanitizerConfig };
        return input.Unsanitize(sanitizerConfigs);
    }

    /// <summary>This method takes multiple sanitizer configs and based on that unsanitize a string.</summary>
    /// <param name="input">Sanitized string.</param>
    /// <param name="sanitizerConfigs">Multiple sanitizer configurations.</param>
    /// <returns>Unsanitized string.</returns>
    /// <exception cref="ArgumentException">It throws ArgumentException when input string is null or empty.</exception>
    /// <exception cref="ArgumentNullException">It throws ArgumentNullException when input config is null.</exception>
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