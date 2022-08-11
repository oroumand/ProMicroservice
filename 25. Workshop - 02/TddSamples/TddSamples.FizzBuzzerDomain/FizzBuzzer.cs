namespace TddSamples.FizzBuzzerDomain;
public class FizzBuzzer
{
    public string GetValue(int input)
    {
        string output = string.Empty;
        if (input % 3 == 0)
            output = "Fizz";
        if (input % 5 == 0)
            output += "Buzz";
        if(string.IsNullOrEmpty(output))
            output = input.ToString();
        return output;
    }
}
