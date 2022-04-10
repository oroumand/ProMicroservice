using ValueObject.Samples;
using ValueObject.Samples.TinyTypes;

namespace ValueObject.ComsoleApps;

public class SampleController
{
    public void AttributeBaseEquality()
    {
        Meter oneMeter01 = new Meter(1);
        Meter oneMeter02 = new Meter(1);

        Meter twoMeter01 = new Meter(2);
        bool oneMeterIsEqualToOneMeter = oneMeter01 == oneMeter02;
        bool oneMeterIsEqualToTowMeter = oneMeter01 == twoMeter01;

        Console.WriteLine($"one meter is equal to one meter? {oneMeterIsEqualToOneMeter}");
        Console.WriteLine($"one meter is equal to tow meter? {oneMeterIsEqualToTowMeter}");
        Console.ReadLine();
    }

    public void Immutable()
    {

        Meter meter = new(2);

        Person person = new Person
        {
            FirstName = "Alireza",
            LastName = "Oroumand",
            Hight = meter
        };

        Car car = new Car
        {
            Name = "Bus",
            Hight = meter,
            Id = 1
        };
        car.Hight = car.Hight.Add(new Meter(2));

        Console.ReadLine();
    }

    public void Combine()
    {
        Meter oneMeter01 = new Meter(1);
        Meter oneMeter02 = new Meter(1);

        Meter twoMeter01 = oneMeter01.Add(new Meter(2));
        Meter twoMeter02 = oneMeter01 + oneMeter02;

        Console.ReadLine();
    }

    public void CreatPerson(string firstName,string lastName)
    {
        Person person = new Person();
        person.FirstName = firstName;
        person.LastName = firstName;
    }

    public void CreateStudent(FirstName firstName, LastName lastName)
    {
        Student student = new Student();
        student.FirstName = firstName;
        student.LastName = lastName;

    }

    public void FactoryMethod()
    {
        TimeSpan ts = TimeSpan.FromDays(1);
        TimeSpan ts1 = TimeSpan.FromHours(1);


        Meter my1000_1 = new Meter(1000);
        Meter my1000_2 = Meter.OneKilometer();

        Customer gold = Customer.Gold("Alireza", "Oroumand");
    }

    public void ShowOverTimeWorking()
    {
        Hour workingHour = new Hour(100);
        Hour contract = new Hour(10);
        OvertimeCalculator overtimeCalculator = new OvertimeCalculator();
        OverTime overTime = overtimeCalculator.Caculate(workingHour, contract);

        new TimeRepository().SaveOverTime(overTime);
    }
}