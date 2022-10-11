using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqSamples.RPC.Server.Models;
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
}

public class CustomerDbContext:DbContext
{
    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=CustomerDb; User Id=sa;Password=1qaz!QAZ");
    }
}


public class CustomerRepository
{
    private readonly CustomerDbContext _context;
    public CustomerRepository()
    {
        _context = new CustomerDbContext();
    }
    public Customer GetById(int id)
    {
        return _context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == id);  
    }
}

