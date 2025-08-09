namespace Arc.StringSanitizer;

/// <summary>Config for string sanitisation.</summary>
public class SanitizerConfig
{
    /// <summary>String to be replaced.</summary>
    public string From { get; set; }

    /// <summary>String replaced with.</summary>
    public string To { get; set; }

    /// <summary>Creates a new object of SanitizerConfig.</summary>
    /// <param name="from">String to be replaced.</param>
    /// <param name="to">String replaced with.</param>
    public SanitizerConfig(string from, string to)
    {
        From = from;
        To = to;
    }
}