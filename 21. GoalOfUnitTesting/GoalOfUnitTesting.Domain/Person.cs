namespace GoalOfUnitTesting.Domain;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }


    //public bool NeedSchoole()
    //{
    //    if (Age > 7 && Age < 18)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public bool NeedSchoole() =>
         Age > 7 && Age < 18;
}
