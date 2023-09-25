namespace Arc.StringSanitizer;

/// <include file='XmlDocs/SanitizerConfig.xml' path='docs/SanitizerConfig/*'/>
public class SanitizerConfig
{
    /// <include file='XmlDocs/SanitizerConfig.xml' path='docs/From/*'/>
    public string From { get; set; }

    /// <include file='XmlDocs/SanitizerConfig.xml' path='docs/To/*'/>
    public string To { get; set; }

    /// <include file='XmlDocs/SanitizerConfig.xml' path='docs/Const/*'/>
    public SanitizerConfig(string from, string to)
    {
        From = from;;
        To = to;
    }
}
