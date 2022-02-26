namespace AppArchSample.Core.Domain;

public class PhoneNumber
{
    public int Id { get; set; }
    public string Number { get; set; }
    private PhoneNumber()
    {

    }
    public PhoneNumber(string number)
    {
        if(number == null || string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentNullException("Invalid input value for PhoneNumber");
        }
        Number = number;
    }

}