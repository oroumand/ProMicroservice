using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CalcSample.Domain.Test;


public class TestDataProviderAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var result = new List<object[]>
        {
            new object[] { 1, true },
            new object[] { -1, false},
        };
        return result;
    }
}
public class TestDataProvider
{
    public static List<object[]> GetDataDrivenValues()
    {
        var result = new List<object[]>
        {
            new object[] { 1, true },
            new object[] { -1, false},
        };
   
        return result;
    }
}
public class CalculatorTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CalculatorTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    [Trait("Group","G1")]
    public void get_true_when_input_is_grater_than_zero()
    {
        //Arrange
        Calculator calculator = new();

        //Act
        var result = calculator.IsGraterThanZero(1);

        //Assert
        _testOutputHelper.WriteLine("My Message");
        Assert.Equal<bool>(true,result);

    }
    [Fact]
    [Trait("Group", "G1")]
    public void get_flase_when_input_is_less_than_zero()
    {
        //Arrange
        Calculator calculator = new();

        //Act
        var result = calculator.IsGraterThanZero(-1);

        //Assert
        _testOutputHelper.WriteLine("My Message");
        Assert.Equal<bool>(false, result);

    }

    [Theory]
    //[InlineData( 1,true)]
    //[InlineData( -1,false)]
    //[InlineData( -2,true)]
    // [MemberData("GetDataDrivenValues",MemberType = typeof(TestDataProvider))]
    [TestDataProvider]
    public void data_driven_test(int input, bool expectedResult)
    {
        //Arrange
        Calculator calculator = new();

        //Act
        var result = calculator.IsGraterThanZero(input);

        //Assert
        _testOutputHelper.WriteLine("My Message");
        Assert.Equal<bool>(expectedResult, result);
    }


    [Fact]
    [Trait("Group", "G1")]

    public void get_four_for_sum_of_one_and_three()
    {
        //arrang
        Calculator calculator = new();

        //Act
        var result = calculator.Sum(1, 3);

        //Assert
        Assert.True(result == 4);

    }

    [Fact]
    [Trait("Group", "G2")]

    public void sum_of_tow_number_should_be_()
    {
        
    }

    [Fact(Skip = "Skip for me")]
    [Trait("Group", "G2")]

    public void fullName_containes_correct_chars()
    {
        //Arrange
        Calculator calculator = new();
        
        calculator.FirstName = "Alireza";
        calculator.LastName = "Oroumand";

        //Act

        //Assert
        Assert.Contains(", ", calculator.FullName);


    }
    [Fact]
    [Trait("Group", "G3")]

    public void throw_correct_exception()
    {
        //Arrange
        Calculator calculator = new();

        //Act

        //var result = calculator.Sum(-1, 2);

        //Assert

        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Sum(-1, 2));
    }
}