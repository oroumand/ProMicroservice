namespace WhatIsUnitTestingSamples.Domain;
public class Store : IStore
{
    private Dictionary<Product, int> _products = new Dictionary<Product, int>();
    public void AddProduct(Product product, int count)
    {
        if (_products.ContainsKey(product))
        {
            _products[product] += count;
        }
        else
        {
            _products[product] = count;
        }
    }

    public void RemoveProduct(Product product, int count)
    {
        if (HasEnoughtInventory(product, count))
        {
            _products[product] -= count;
        }
    }

    public bool HasEnoughtInventory(Product product, int count)
    {
        return _products.ContainsKey(product) && _products[product] >= count;
    }

    public int Inventory(Product product)
    {
        if (_products.ContainsKey(product))
        {
            return _products[product];
        }
        return 0;
    }
}
