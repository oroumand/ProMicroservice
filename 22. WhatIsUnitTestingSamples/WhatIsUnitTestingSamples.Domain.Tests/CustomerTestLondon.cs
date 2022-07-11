using Xunit;

namespace WhatIsUnitTestingSamples.Domain.Tests;
public class CustomerTestClasic
{
    [Fact]
    public void Purchase_Done_Correct_Whene_Has_Enough_Inventory()
    {
        //Arrange
        Store store = new Store();
        Product laptop = new Product
        {
            Name = "Laptop"
        };

        store.AddProduct(laptop, 10);

        var sut = new Customer();
        //Act
        var result = sut.Purchase(store, laptop, 2);
        
        
        //Assert
        Assert.True(result);
        Assert.Equal(8, store.Inventory(laptop));
        Assert.Equal(2, sut.Inventory(laptop));

    }

    [Fact]
    public void Purchase_Failed_Correct_Whene_Has_Not_Enough_Inventory()
    {
        //Arrange
        IStore store = new NotEnuoghInventoryStore();
        Product laptop = new Product
        {
            Name = "Laptop"
        };
        var sut = new Customer();
        //Act
        var result = sut.Purchase(store, laptop, 2);

        //Assert
        Assert.False(result);
    }
}