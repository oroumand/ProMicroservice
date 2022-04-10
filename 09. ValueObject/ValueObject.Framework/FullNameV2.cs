namespace ValueObject.Framework;

public class FullNameV2 : BaseValueObjectV2<FullNameV2>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public FullNameV2(string firstName, string lastName)
    {
        //Validation
        FirstName = firstName;
        LastName = lastName;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}