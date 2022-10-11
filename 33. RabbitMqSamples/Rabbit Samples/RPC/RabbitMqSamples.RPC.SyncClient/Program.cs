using RabbitMqSamples.RPC.SyncClient.Models;
CustomerCaller CustomerCaller = new CustomerCaller();
bool getAnotherCustomer = false;
do
{
    Console.WriteLine("Please send customer Id:");
    int customerId =int.Parse(Console.ReadLine());
    var customer = CustomerCaller.Get(customerId);
    Console.WriteLine($"Customerid:{customer.CustomerId},\t Customer name: {customer.Name},\t Customer family:{customer.Family}");

    Console.WriteLine("Do you want to continue? y/n");
    var input = Console.ReadLine();
    getAnotherCustomer = input == "y";
} while (getAnotherCustomer);

CustomerCaller.CloseConnection();
Console.WriteLine("Press [Enter] to exit.");
Console.ReadLine();