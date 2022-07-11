namespace WhatIsUnitTestingSamples.Domain;

public class Customer
{
    private Dictionary<Product, int> _basket = new Dictionary<Product, int>();

    public bool Purchase(IStore store, Product product, int count)
    {
        if(store.HasEnoughtInventory(product,count))
        {
            store.RemoveProduct(product, count);
            AddToBasket(product,count);
            return true;
        }

        return false;
    }


    private void AddToBasket(Product product, int count)
    {
        if (_basket.ContainsKey(product))
        {
            _basket[product] += count;
        }
        else
        {
            _basket[product] = count;
        }
    }

    public int Inventory(Product product)
    {
        if (_basket.ContainsKey(product))
        {
            return _basket[product];
        }
        return 0;
    }
}