namespace ValueObject.EFSample;

public class LastName
{
    public string Value { get; private set; }
    public LastName(string value)
    {
        Value = value;  
    }
}