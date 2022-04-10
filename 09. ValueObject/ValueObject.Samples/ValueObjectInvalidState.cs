namespace ValueObject.Samples;

public class ValueObjectInvalidState : DomainException
{
    public ValueObjectInvalidState(string message) : base(message)
    {
    }
}