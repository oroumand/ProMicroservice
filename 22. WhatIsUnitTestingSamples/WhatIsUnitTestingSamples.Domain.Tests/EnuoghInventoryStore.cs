namespace WhatIsUnitTestingSamples.Domain.Tests;

public class EnuoghInventoryStore : IStore
{
    public void AddProduct(Product product, int count)
    {
        throw new System.NotImplementedException();
    }

    public bool HasEnoughtInventory(Product product, int count)
    {
        return true;
    }

    public int Inventory(Product product)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveProduct(Product product, int count)
    {
    }
}


public class NotEnuoghInventoryStore : IStore
{
    public void AddProduct(Product product, int count)
    {
        throw new System.NotImplementedException();
    }

    public bool HasEnoughtInventory(Product product, int count)
    {
        return false;
    }

    public int Inventory(Product product)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveProduct(Product product, int count)
    {
    }
}
