using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatesSamples.Introdutions.Products;

public class Product
{
    public string Name { get; set; }
    public Discount Discount { get; set; }
    public int Price { get; set; }
    public void AddDiscount(int value)
    {
        if (Price - value < 1)
        {
            throw new ArgumentException("Invalid value for discount value");
        }
        Discount = new Discount
        {
            DiscountValue = value
        };
    }
}
