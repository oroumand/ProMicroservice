namespace CalcSample.Domain;
public class Calculator
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName}, {LastName}";
    public int Sum(int num1, int num2)
    {
        if(num1 < 0 || num2 < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        return num1 + num2; 
    }

    public bool IsGraterThanZero(int input) => input > 0;


}


public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName}, {LastName}";

}

public class Teacher:Person
{


}

public class Student:Person
{

}

public class PersonFactory
{
    public static Person GetPersonOfType(PersonType personType)
    {
        return personType == PersonType.Student ? new Student() : new Teacher();
    }
}

public enum PersonType
{
    Student,
    Teacher
}