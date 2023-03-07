using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModel;
using Xunit;

namespace StoreTest;

public class CostumerTest
{
    [Fact]
    public void TestDataInt()
    {
        //Arrange
        Costumer newCostumer = new Costumer();
        int costumerId = 1010;

        //Act
        newCostumer.CostumerId = costumerId;

        //Assert
        Assert.NotNull(newCostumer.CostumerId);
        Assert.Equal(costumerId, newCostumer.CostumerId);

    }

    [Fact]
    public void TestDataString()
    {
        //Arrange
        Costumer newCostumer = new Costumer();
        string costumerName = "Nancy";
        string costumerPhone = "415-555-5555";
        string costumerAddress = "555 River St. San Francisco CA";
        string costumerEmail = "nancy@email.com";

        //Act
        newCostumer.Name = costumerName;
        newCostumer.Phone = costumerPhone;
        newCostumer.Address = costumerAddress;
        newCostumer.Email = costumerEmail;

        //Assert

        Assert.NotNull(newCostumer.Name);
        Assert.Equal(costumerName, newCostumer.Name);

        Assert.NotNull(newCostumer.Phone);
        Assert.Equal(costumerPhone, newCostumer.Phone);

        Assert.NotNull(newCostumer.Address);
        Assert.Equal(costumerAddress, newCostumer.Address);

        Assert.NotNull(newCostumer.Email);
        Assert.Equal(costumerEmail, newCostumer.Email);

    }

    [Fact]
    public void CostumerList()
    {
        //Arrange
        int costumerId = 1010;
        string costumerName = "Nancy";
        string costumerPhone = "415-555-5555";
        string costumerAddress = "555 River St. San Francisco CA";
        string costumerEmail = "nancy@email.com";

        Costumer expectedCostumer = new Costumer()
        {
            CostumerId = costumerId,
            Name = costumerName,
            Phone = costumerPhone,
            Address = costumerAddress,
            Email = costumerEmail,
        };

        List<Costumer> expectedCostumerList = new List<Costumer>();
        expectedCostumerList.Add(expectedCostumer);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.ListOfCostumers()).Returns(expectedCostumerList);

        ICostumerBL costumerBL = new CostumerBL(mockRepo.Object);

        //Act
        List<Costumer> actualCostumerList = costumerBL.FindCostumer(expectedCostumer.CostumerId);


        //Assert
        Assert.Equal(expectedCostumerList, actualCostumerList);
    }

    [Fact]
    public void TestCreateCostumerId()
    {
        //Arrange
        int expectedCostumerId = 1000;
    

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.createCostumerId()).Returns(expectedCostumerId);

        ICostumerBL costumerBL = new CostumerBL(mockRepo.Object);

        //Act
        int actualCostumerId = costumerBL.CreateCostumerId();


        //Assert
        Assert.Equal(expectedCostumerId, actualCostumerId);
    }

    public void TestCreateOrderId()
    {
        //Arrange
        int expectedOrderId = 300010;
    

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.createOrderId()).Returns(expectedOrderId);

        ICostumerBL costumerBL = new CostumerBL(mockRepo.Object);

        //Act
        int actualOrderId = costumerBL.CreateOrderId();


        //Assert
        Assert.Equal(expectedOrderId, actualOrderId);
    }
}