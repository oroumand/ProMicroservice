using RabbitMqSamples.RPC.AsyncClient.Models;
CustomerCaller CustomerCaller = new CustomerCaller(PrintCustomer);
bool getAnotherCustomer = false;
do
{
    Console.WriteLine("Please send customer Id:");
    int customerId = int.Parse(Console.ReadLine());
    CustomerCaller.Get(customerId);
    Console.WriteLine("Do you want to continue? y/n");
    var input = Console.ReadLine();
    getAnotherCustomer = input == "y";
} while (getAnotherCustomer);

CustomerCaller.CloseConnection();
Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();

void PrintCustomer(Customer customer)
{
    Console.WriteLine($"Customerid:{customer.CustomerId},\t Customer name: {customer.Name},\t Customer family:{customer.Family}");
}