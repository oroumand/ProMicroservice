using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;
using IOutput = PactNet.Infrastructure.Outputters.IOutput;

namespace PersonProviderTest;

public class XUnitOutput : IOutput
{
    private readonly ITestOutputHelper _outputHelper;
    public XUnitOutput(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    public void Write(string message, OutputLevel level)
    {
        _outputHelper.WriteLine(message);
    }

    public void WriteLine(string message, OutputLevel level)
    {
        _outputHelper.WriteLine(message);
    }

    public void WriteLine(string line)
    {
        _outputHelper.WriteLine(line);
    }


}