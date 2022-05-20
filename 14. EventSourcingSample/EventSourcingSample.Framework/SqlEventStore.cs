using Dapper;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace EventSourcingSample.Framework;
public class EventStoreItem
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Sequence { get; set; }
    public int Version { get; set; }
    public string Name { get; set; }
    public string AggregateId { get; set; }
    public string Data { get; set; }
    public string Aggregate { get; set; }
}
public class SqlEventStore : IEventStore
{
    private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        NullValueHandling = NullValueHandling.Ignore,
    };
    private readonly IDbConnection _db = new SqlConnection("Server=.; Initial Catalog=EventSourcing; User Id=sa; Password=1qaz!QAZ");
    public SqlEventStore()
    {

    }
    public IReadOnlyList<IDomainEvent> Get(string aggregateTypeName, long id)
    {
        string selectCommand = "Select * from EventStore Where Aggregate=@Aggregate and  AggregateId=@Id";
        var parameters = new
        {
            Aggregate = aggregateTypeName,
            Id = id.ToString(),
        };

        List<EventStoreItem> eventStoreItems = _db.Query<EventStoreItem>(selectCommand, parameters).ToList();

        List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        foreach (var item in eventStoreItems)
        {
            var myObject = JsonConvert.DeserializeObject(item.Data,_serializerSettings);
            domainEvents.Add(myObject as IDomainEvent);
        }

        return domainEvents;
    }

    public void Save(string aggregateTypeName, long id, int currentVersion,IReadOnlyList<IDomainEvent> domainEvents)
    {
        string insertCommand = "Insert Into EventStore(Id,CreatedAt,Version,Name,AggregateId,Data,Aggregate)" +
            " values (@Id,@CreatedAt,@Version,@Name,@AggregateId,@Data,@Aggregate)";
        DateTime createdAt = DateTime.Now;
        var itemToSave = domainEvents.Select(c => new
        {
            Id = Guid.NewGuid(),
            CreatedAt = createdAt,
            Version = ++currentVersion,
            Name = c.GetType().Name,
            AggregateId = id,
            Data = JsonConvert.SerializeObject(c, _serializerSettings),
            Aggregate = aggregateTypeName

        }).ToList();
        _db.Execute(insertCommand, itemToSave);
    }
}