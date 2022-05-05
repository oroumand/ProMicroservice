using AggregatesSamples.Framework;

namespace AggregatesSamples.Introdutions.AddressBooks;

public class AddressLine:Entity
{
    public int Id { get; set; }
    public int AddressBookId { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public bool IsDefault { get; set; }
}