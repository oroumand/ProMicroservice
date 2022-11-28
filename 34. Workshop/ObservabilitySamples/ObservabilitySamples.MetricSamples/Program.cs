// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;

Meter s_meter = new Meter("MicroserviceCourse", "1.0.0"); 
Counter<int> SoldCount= s_meter.CreateCounter<int>("course-sold");

for (int i = 0; i < 1000; i++)
{
    SoldCount.Add(i);
    Console.WriteLine($"{i}");
    System.Threading.Thread.Sleep(2000);
}