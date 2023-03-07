using System.Collections.Generic;
using StoreModel;
using StoreBL;
using StoreDL;
using Moq;

using Xunit;

namespace StoreTest;

public class OrderProductTest
{
    [Fact]
    public void TestDataInt()
    {
        //Arrange
            OrderProduct newOrderProduct = new OrderProduct();
            int productId = 112339;
            int productQuantity = 1;
            


            //Act
            newOrderProduct.ProductId = productId;
            newOrderProduct.ProductQuantity = productQuantity;

            //Assert
            Assert.NotNull(newOrderProduct.ProductId);
            Assert.Equal(productId, newOrderProduct.ProductId);

            Assert.NotNull(newOrderProduct.ProductQuantity);
            Assert.Equal(productQuantity, newOrderProduct.ProductQuantity);
    }

    [Fact]
    public void TestDataString()
    {
        //Arrange
            OrderProduct newOrderProduct = new OrderProduct();
            double productCost = 12.99;
            double totalCost = 12.99;

            //Act
            newOrderProduct.ProductCost = productCost;
            newOrderProduct.TotalCost = totalCost;

            //Assert
            Assert.NotNull(newOrderProduct.ProductCost);
            Assert.Equal(productCost, newOrderProduct.ProductCost);

            Assert.NotNull(newOrderProduct.TotalCost);
            Assert.Equal(totalCost, newOrderProduct.TotalCost);
    }

    [Fact]
    public void TestDataDouble()
    {
        //Arrange
            OrderProduct newOrderProduct = new OrderProduct();
            string productName = "Pure Leaf Raspberry";
            string productDescription = "Pure Leaf Iced Tea Raspberry flavored 18.5 fl oz bottle";

            //Act
            newOrderProduct.ProductName = productName;
            newOrderProduct.ProductDescription = productDescription;

            //Assert
            Assert.NotNull(newOrderProduct.ProductName);
            Assert.Equal(productName, newOrderProduct.ProductName);

            Assert.NotNull(newOrderProduct.ProductDescription);
            Assert.Equal(productDescription, newOrderProduct.ProductDescription);
    }

}