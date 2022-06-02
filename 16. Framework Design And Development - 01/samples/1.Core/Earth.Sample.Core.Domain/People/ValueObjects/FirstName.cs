using Earth.Core.Domain.Exceptions;
using Earth.Core.Domain.ValueObjects;
using Earth.Utilities.Extensions;
namespace Earth.Samples.Core.Domain.People.ValueObjects;

public class FirstName : BaseValueObject<FirstName>
{
    public string Value { get; private set; }
    public FirstName(string value)
    {
        value = value.Trim();

        if (string.IsNullOrEmpty(value))
            throw new InvalidValueObjectStateException(Messages.InvalidNullValue, Messages.FirstName);
        if (value.IsLengthBetween(2, 50))
            throw new InvalidValueObjectStateException(Messages.InvalidStringLenght, Messages.FirstName, "2", "50");
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
