// See https://aka.ms/new-console-template for more information
using TddSamples.FizzBuzzerDomain;

FizzBuzzer _fizzBuzzer = new();

for (int i = 1; i < 100; i++)
{
    Console.WriteLine(_fizzBuzzer.GetValue(i));
}
