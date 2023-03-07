using System.Collections.Generic;
using StoreModel;
using StoreBL;
using StoreDL;
using Moq;

using Xunit;

namespace StoreTest;

public class ProductsTest
{
    [Fact]
    public void ProductsDataInt()
    {
        //Arrange
            Products newProduct = new Products();
            int productId = 112339;


            //Act
            newProduct.ProductId = productId;

            //Assert
            Assert.NotNull(newProduct.ProductId);
            Assert.Equal(productId, newProduct.ProductId);
    }

    [Fact]
    public void ProductsDataDouble()
    {
        //Arrange
            Products newProduct = new Products();
            double productPrice = 1.99;


            //Act
            newProduct.ProductPrice = productPrice;
            //Assert
            Assert.NotNull(newProduct.ProductPrice);
            Assert.Equal(productPrice, newProduct.ProductPrice);

    }

    [Fact]
    public void ProductsDataString()
    {
        //Arrange
            Products newProduct = new Products();
            string productName = "Dunkin Coffee Mocha";
            string productDescription = "Dunkin Donuts Mocha - 13.7 fl oz Bottle";
            string ProductCategory = "Drinks";


            //Act
            newProduct.ProductName = productName;
            newProduct.ProductDescription = productDescription;
            newProduct.ProductCategory = ProductCategory;

            //Assert
            Assert.NotNull(newProduct.ProductName);
            Assert.Equal(productName, newProduct.ProductName);

            Assert.NotNull(newProduct.ProductDescription);
            Assert.Equal(productDescription, newProduct.ProductDescription);

            Assert.NotNull(newProduct.ProductCategory);
            Assert.Equal(ProductCategory, newProduct.ProductCategory);

    }

    [Fact]
    public void ProductList()
    {
        //Arrange
        int productId = 112339;
        string productName = "Dunkin Coffee Mocha";
        double productPrice = 1.99;
        string productDescription = "Dunkin Donuts Mocha - 13.7 fl oz Bottle";
        string ProductCategory = "Drinks";

        Products newProduct = new Products()
        {
            ProductId = productId,
            ProductName = productName,
            ProductPrice = productPrice,
            ProductDescription = productDescription,
            ProductCategory = ProductCategory

        };

        List<Products> expectedList = new List<Products>();
        expectedList.Add(newProduct);

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.ListOfProducts()).Returns(expectedList);

        IStoreFrontBL storeFrontBL = new StoreFrontBL(mockRepo.Object);

        //Act
        List<Products> actualList = storeFrontBL.listOfProducts();

        //Assert
        Assert.Equal(expectedList, actualList);
    }
}