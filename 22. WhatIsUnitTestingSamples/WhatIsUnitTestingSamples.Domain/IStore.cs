namespace WhatIsUnitTestingSamples.Domain;

public interface IStore
{
    void AddProduct(Product product, int count);
    bool HasEnoughtInventory(Product product, int count);
    int Inventory(Product product);
    void RemoveProduct(Product product, int count);
}