using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModel;
using Xunit;

namespace StoreTest;

public class StoreEmployeeTest
{
    [Fact]
    public void TestDataIntEmployee()
    {
        //Arrange
        Employee newEmployee = new Employee();
        int employeeId = 123456;
        int employeePassword = 654321;

        //Act
        newEmployee.EmployeeId = employeeId;
        newEmployee.EmployeePassword = employeePassword;

        //Assert
        Assert.NotNull(newEmployee.EmployeeId);
        Assert.Equal(employeeId, newEmployee.EmployeeId);

        Assert.NotNull(newEmployee.EmployeePassword);
        Assert.Equal(employeePassword, newEmployee.EmployeePassword);

    }

    [Fact]
    public void TestDataIntManager()
    {
        //Arrange
        Manager newManager = new Manager();
        int managerId = 987654;
        int managerPassword = 456789;

        //Act
        newManager.ManagerId = managerId;
        newManager.ManagerPassword = managerPassword;

        //Assert
        Assert.NotNull(newManager.ManagerId);
        Assert.Equal(managerId, newManager.ManagerId);

        Assert.NotNull(newManager.ManagerPassword);
        Assert.Equal(managerPassword, newManager.ManagerPassword);

    }

    [Fact]
    public void TestVerifyEmployee()
    {
        //Arrange
        List<Employee> expectedEmployeeList = new List<Employee>();

        Employee currEmployee = new Employee()
        {
            EmployeeId = 123456,
            EmployeePassword = 654321
        };

        expectedEmployeeList.Add(currEmployee);
    

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetEmployeeList()).Returns(expectedEmployeeList);

        IStoreFrontBL storeFrontBL = new StoreFrontBL(mockRepo.Object);

        //Act
        bool found = storeFrontBL.VerifyEmployee(currEmployee.EmployeeId, currEmployee.EmployeePassword);


        //Assert
        Assert.True(found);
    }

    [Fact]
    public void TestVerifyManager()
    {
        //Arrange
        List<Employee> expectedManagerList = new List<Employee>();

        Employee currEmployee = new Employee()
        {
            EmployeeId = 142536,
            EmployeePassword = 123456
        };

        expectedManagerList.Add(currEmployee);
    

        Mock<IRepository> mockRepo = new Mock<IRepository>();

        mockRepo.Setup(repo => repo.GetEmployeeList()).Returns(expectedManagerList);

        IStoreFrontBL storeFrontBL = new StoreFrontBL(mockRepo.Object);

        //Act
        bool found = storeFrontBL.VerifyEmployee(currEmployee.EmployeeId, currEmployee.EmployeePassword);


        //Assert
        Assert.True(found);
    }

}