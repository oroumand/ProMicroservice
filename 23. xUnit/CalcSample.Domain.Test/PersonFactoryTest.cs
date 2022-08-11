using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcSample.Domain.Test;
public class PersonFactoryTest
{
    [Fact]
    public void can_create_student()
    {
        //Arrange
        Person p = PersonFactory.GetPersonOfType(PersonType.Student);

        //Act

        //Assert

        Assert.IsType<Student>(p);

    }

    [Fact]
    public void can_create_person()
    {
        //Arrange
        Person p = PersonFactory.GetPersonOfType(PersonType.Student);

        //Act

        //Assert

        Assert.IsAssignableFrom<Person>(p);

    }
}
