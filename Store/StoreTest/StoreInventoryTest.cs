using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModel;
using Xunit;

namespace StoreTest;

public class StoreInventoryTest
{
    [Fact]
    public void StoreInventoryDataInt()
    {
        //Arrange
        
        StoreInventory newInstance = new StoreInventory();
        int storeNumber = 135;
        int productId = 112289;
        int quantity = 45;


        //Act
        newInstance.StoreNumber = storeNumber;
        newInstance.ProductId = productId;
        newInstance.Quantity = quantity;

        //Assert
        Assert.NotNull(newInstance.StoreNumber);
        Assert.Equal(storeNumber, newInstance.StoreNumber);

        Assert.NotNull(newInstance.ProductId);
        Assert.Equal(productId, newInstance.ProductId);

        Assert.NotNull(newInstance.Quantity);
        Assert.Equal(quantity, newInstance.Quantity);

    }

    [Fact]
    public void StoreInventoryList()
    {
         //Arrange
        int storeNumber = 135;
        int productId = 112289;
        int quantity = 45;

        StoreInventory newInstance = new StoreInventory()
        {
            StoreNumber = storeNumber,
            ProductId = productId,
            Quantity = quantity
        };

        List<StoreInventory> expectedList = new List<StoreInventory>();
        expectedList.Add(newInstance);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.ListInventory(storeNumber)).Returns(expectedList);

        IStoreFrontBL storeFrontBL = new StoreFrontBL(mockRepo.Object);
        //Act
        List<StoreInventory> actualList = storeFrontBL.listInventory(storeNumber);

        //Assert
        Assert.Equal(expectedList, actualList);
    }
}