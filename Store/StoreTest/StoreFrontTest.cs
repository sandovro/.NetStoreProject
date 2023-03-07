using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModel;
using Xunit;

namespace StoreTest;

public class StoreFrontTest
{
    [Fact]
    public void TestDataIntStore()
    {
        //Arrange
        StoreFront newStoreFront = new StoreFront();
        int storeNumber = 135;

        //Act
        newStoreFront.StoreNumber = storeNumber;

        //Assert
        Assert.NotNull(newStoreFront.StoreNumber);
        Assert.Equal(storeNumber, newStoreFront.StoreNumber);

    }

    [Fact]
    public void TestDataStringStore()
    {
        //Arrange
        StoreFront newStoreFront = new StoreFront();
        string storeName = "Creekside";
        string storeAddress = "51536 Primera Ave, San Jose, CA";

        //Act
        newStoreFront.StoreName = storeName;
        newStoreFront.StoreAddress = storeAddress;

        //Assert
        Assert.NotNull(newStoreFront.StoreName);
        Assert.Equal(storeName, newStoreFront.StoreName);

        Assert.NotNull(newStoreFront.StoreAddress);
        Assert.Equal(storeAddress, newStoreFront.StoreAddress);

    }

    [Fact]
    public void TestDataIntLineItem()
    {
        //Arrange
        LineItems newLineItem = new LineItems();
        int orderNumber = 300010;
        int productId = 112255;
        int quantity = 3;

        //Act
        newLineItem.OrderNumber = orderNumber;
        newLineItem.ProductId = productId;
        newLineItem.Quantity = quantity;

        //Assert
        Assert.NotNull(newLineItem.OrderNumber);
        Assert.Equal(orderNumber, newLineItem.OrderNumber);

        Assert.NotNull(newLineItem.ProductId);
        Assert.Equal(productId, newLineItem.ProductId);

        Assert.NotNull(newLineItem.Quantity);
        Assert.Equal(quantity, newLineItem.Quantity);

    }

        public double ProductTotal { get; set; }

    [Fact]
    public void TestDataDoubleLineItem()
    {
        //Arrange
        LineItems newLineItem = new LineItems();
        double productTotal = 5.99;

        //Act
        newLineItem.ProductTotal = productTotal;

        //Assert
        Assert.NotNull(newLineItem.ProductTotal);
        Assert.Equal(productTotal, newLineItem.ProductTotal);

    }

    

    


}