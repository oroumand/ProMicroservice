namespace AppArchSample.Core.Domain;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<PhoneNumber> PhoneNumbers { get; set; }=new List<PhoneNumber>();
    private Person()
    {

    }
    public Person(string firstName,string lastName,PhoneNumber phoneNumber)
    {
        if(firstName== null || lastName == null || phoneNumber == null)
        {
            throw new ArgumentNullException("Invalid input value for person");
        }
        FirstName = firstName;
        LastName = lastName;
        PhoneNumbers.Add(phoneNumber);
    }

    public void AddPhoneNumber(PhoneNumber phoneNumber)
    {
        if(PhoneNumbers.Any(c=> c.Number == phoneNumber.Number))
        {
            throw new InvalidDataException("PhoneNumber is Duplicate");
        }
        PhoneNumbers.Add(phoneNumber);
    }
}
