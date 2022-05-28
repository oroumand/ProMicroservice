using EventStore.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.Framework;

public class EsEventStore : IEventStore
{
    private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        NullValueHandling = NullValueHandling.Ignore,
    };
    private readonly EventStoreClient _clinet;
    public EsEventStore()
    {
        var settings = EventStoreClientSettings.Create("esdb://admin:changeit@127.0.0.1:2113?tls=true&tlsVerifyCert=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        _clinet = new EventStoreClient(settings);
    }
    public IReadOnlyList<IDomainEvent> Get(string aggregateTypeName, long id)
    {
        string streamId = GetStreamId(aggregateTypeName, id);
        var result = _clinet.ReadStreamAsync(
            Direction.Forwards,
            streamId,
            StreamPosition.Start);

        var events =  result.ToListAsync().Result;
        var domainEvents = events.Select(e => GetDomainEvent(e.Event.Data.ToArray())).ToList();
        return domainEvents;
    }

    private IDomainEvent GetDomainEvent(byte[] data)
    {
        var str = Encoding.UTF8.GetString(data);
        var myObject = JsonConvert.DeserializeObject(str, _serializerSettings);
        var domainEvent = myObject as IDomainEvent;
        return domainEvent;
    }

    public void Save(string aggregateTypeName, long id, int currentVersion, IReadOnlyList<IDomainEvent> domainEvents)
    {
        string streamId = GetStreamId(aggregateTypeName, id);
        IEnumerable <EventData> eventData= domainEvents.Select(c => new EventData(Uuid.NewUuid(),
            c.GetType().Name,
            GetSerializedEventData(c)
            ));
        _clinet.AppendToStreamAsync(
            streamId,
            StreamState.Any,
           eventData
        ).Wait();
    }

    private ReadOnlyMemory<byte> GetSerializedEventData(IDomainEvent c)
    {
        var jsonEvent = JsonConvert.SerializeObject(c, _serializerSettings);
        var byteArray = Encoding.UTF8.GetBytes(jsonEvent);
        return byteArray;
    }

    private string GetStreamId(string aggregateTypeName, long id)
        => $"{aggregateTypeName}-{id}";
}