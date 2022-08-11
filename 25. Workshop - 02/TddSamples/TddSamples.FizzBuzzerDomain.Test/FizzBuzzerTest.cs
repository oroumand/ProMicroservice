namespace TddSamples.FizzBuzzerDomain.Test;

public class FizzBuzzerTest
{
    //[Fact]
    //public void fizzbuzzer_return_one_when_receive_one()
    //{
    //    //Arrange
    //    int input = 1;
    //    string expected = "1";

    //    FizzBuzzer fizzBuzzer = new();

    //    //Act
    //    string actualResult = fizzBuzzer.GetValue(input);

    //    //Assert
    //    Assert.Equal(expected, actualResult);
    //}
    //[Fact]

    //public void fizzbuzzer_return_tow_when_receive_tow()
    //{
    //    //Arrange
    //    int input = 2;
    //    string expected = "2";

    //    FizzBuzzer fizzBuzzer = new();

    //    //Act
    //    string actualResult = fizzBuzzer.GetValue(input);

    //    //Assert
    //    Assert.Equal(expected, actualResult);
    //}

    //[Fact]
    //public void fizzbuzzer_return_fizz_when_receive_three()
    //{
    //    //Arrange
    //    int input = 3;
    //    string expected = "Fizz";
    //    FizzBuzzer fizzBuzzer = new();

    //    //Act
    //    string actualResult = fizzBuzzer.GetValue(input);

    //    //Assert
    //    Assert.Equal(expected, actualResult);
    //}
    //[Fact]
    //public void fizzbuzzer_return_four_when_receive_four()
    //{
    //    //Arrange
    //    int input = 4;
    //    string expected = "4";
    //    FizzBuzzer fizzBuzzer = new();

    //    //Act
    //    string actualResult = fizzBuzzer.GetValue(input);

    //    //Assert
    //    Assert.Equal(expected, actualResult);
    //}


    //[Fact]
    //public void fizzbuzzer_return_bizz_when_receive_Five()
    //{
    //    //Arrange
    //    int input = 5;
    //    string expected = "Buzz";
    //    FizzBuzzer fizzBuzzer = new();

    //    //Act
    //    string actualResult = fizzBuzzer.GetValue(input);

    //    //Assert
    //    Assert.Equal(expected, actualResult);
    //}

    //[Fact]
    //public void fizzbuzzer_return_fizz_when_receive_six()
    //{
    //    //Arrange
    //    int input = 6;
    //    string expected = "Fizz";
    //    FizzBuzzer fizzBuzzer = new();

    //    //Act
    //    string actualResult = fizzBuzzer.GetValue(input);

    //    //Assert
    //    Assert.Equal(expected, actualResult);
    //}

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(11)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(19)]
    [InlineData(22)]
    [InlineData(23)]
    [InlineData(26)]
    [InlineData(28)]
    [InlineData(29)]

    public void fizzbuzzer_return_actual_number_when_receive_simple_number(int input)
    {
        //Arrange
        string expected = input.ToString();
        FizzBuzzer fizzBuzzer = new();
        //Act
        string actualResult = fizzBuzzer.GetValue(input);
        //Assert
        Assert.Equal(expected, actualResult);
    }


    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    [InlineData(18)]
    [InlineData(21)]
    [InlineData(24)]
    [InlineData(27)]
    [InlineData(33)]

    public void fizzbuzzer_return_fizz_when_receive_divthree(int input)
    {
        //Arrange
        string expected = "Fizz";
        FizzBuzzer fizzBuzzer = new();

        //Act
        string actualResult = fizzBuzzer.GetValue(input);

        //Assert
        Assert.Equal(expected, actualResult);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(25)]
    [InlineData(40)]
    public void fizzbuzzer_return_buzz_when_receive_divFive(int input)
    {
        //Arrange
        string expected = "Buzz";
        FizzBuzzer fizzBuzzer = new();

        //Act
        string actualResult = fizzBuzzer.GetValue(input);

        //Assert
        Assert.Equal(expected, actualResult);
    }


    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    [InlineData(60)]
    public void fizzbuzzer_return_buzz_when_receive_divThree_and_divFive(int input)
    {
        //Arrange
        string expected = "FizzBuzz";
        FizzBuzzer fizzBuzzer = new();

        //Act
        string actualResult = fizzBuzzer.GetValue(input);

        //Assert
        Assert.Equal(expected, actualResult);
    }

}