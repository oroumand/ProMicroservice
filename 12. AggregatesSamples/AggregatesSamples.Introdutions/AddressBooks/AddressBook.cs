using AggregatesSamples.Framework;

namespace AggregatesSamples.Introdutions.AddressBooks;

public class AddressBook:AggregateRoot
{
    public int CustomerId { get; set; }
    private readonly List<AddressLine> _addressLines = new();
    public IReadOnlyList<AddressLine> AddressLines => _addressLines;
    public void AddAddressLine(string address, string city, bool isDefault)
    {
        AddressLine addressLine = new AddressLine
        {
            Address = address,
            City = city,
            IsDefault = isDefault,
        };
        if(isDefault)
        {
            foreach (var item in _addressLines)
            {
                item.IsDefault = false;
            }           
        }
        _addressLines.Add(addressLine);
    }
    public AddressLine GetDefault()
    {
        return AddressLines.Where(c => c.IsDefault).Single();
    }
}
