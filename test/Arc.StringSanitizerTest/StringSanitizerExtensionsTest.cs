namespace Arc.StringSanitizerTest;

public partial class StringSanitizerExtensionsTest
{
    private readonly SanitizerConfig _sanitizerConfig;
    private readonly List<SanitizerConfig> _sanitizerConfigs;

    public StringSanitizerExtensionsTest()
    {
        _sanitizerConfig = new SanitizerConfig("special char", "[sc]");

        _sanitizerConfigs = new List<SanitizerConfig>()
        {
            new SanitizerConfig("special char", "[sc]"),
            new SanitizerConfig("&nbsp;", "[html space]")
        };
    }
}