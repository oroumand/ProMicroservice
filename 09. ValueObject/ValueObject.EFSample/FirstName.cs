namespace ValueObject.EFSample;

public class FirstName
{
    public string Value { get;private set; }
    private FirstName()
    {

    }
    public FirstName(string value)
    {
        //Checking

        Value = value;
    }

}
