using AggregatesSamples.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatesSamples.Introdutions.Customers;

public class Customer:AggregateRoot
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}