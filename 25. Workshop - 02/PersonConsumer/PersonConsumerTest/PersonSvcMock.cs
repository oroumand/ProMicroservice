using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace PersonConsumerTest;
public class PersonSvcMock : IDisposable
{
    private readonly IPactBuilder _builder;
    private readonly int _port = 9000;
    private bool  _disposed;
    public string ServiceUri => $"http://localhost:{_port}";
    public IMockProviderService MockProviderService { get; }

    public PersonSvcMock()
    {
        var pactConfig = new PactConfig
        {
            SpecificationVersion = "2.0.0",
            PactDir = @"F:\Pact\PersonConsumer",
            LogDir = @"F:\Pact\PersonConsumer\logs"
        };

        _builder = new PactBuilder(pactConfig)
            .ServiceConsumer("PersonConsumer")
            .HasPactWith("PersonProvider");

        MockProviderService = _builder.MockService(_port, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
        });
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
                _builder.Build();
            }
            _disposed = true;
        }
    }
}
