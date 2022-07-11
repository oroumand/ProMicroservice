using Xunit;

namespace GoalOfUnitTesting.Domain.Tests;
public class PersonTest
{
    [Fact]
    public void Check_Need_To_School()
    {
        Person person = new Person
        {
            Age = 15
        };

        bool result = person.NeedSchoole();

        Assert.True(result);
    }
}