using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;

namespace PersonProviderTest;

public class PeopleServiceTests : IDisposable
{
    private bool _disposed;
    private readonly ITestOutputHelper _output;
    private readonly string _url;

    public PeopleServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _url = "http://localhost:8080";
    }

    [Fact]
    public void VerifyPeopleService()
    {
        var config = new PactVerifierConfig
        {
            Verbose = true,
            ProviderVersion = "2.0.0",
            CustomHeaders = new Dictionary<string, string>
            {
                {"Content-Type","application/json; charset=utf-8" }
            },
            Outputters = new List<IOutput>
            {
                new XUnitOutput(_output)
            }
           
        };

        new PactVerifier(config)
            .ServiceProvider("PersonProvider", _url)
            .HonoursPactWith("PersonConsumer")
            .PactUri(@"F:\Pact\PersonConsumer\personconsumer-personprovider.json")
            .Verify();
    }


    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if(!_disposed)
        {
            if(disposing)
            {
                //
            }
            _disposed = true;
        }
    }
}
