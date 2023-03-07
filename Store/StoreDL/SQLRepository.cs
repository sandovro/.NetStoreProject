using System.Data.SqlClient;
using StoreModel;

namespace StoreDL;

public class SQLRepository : IRepository
{
    private readonly string _connectionString;
    public SQLRepository(string p_connectionString)
    {
        _connectionString = p_connectionString;
    }

    public Costumer AddCostumer(Costumer p_costumer)
    {
        string sqlQuery = @"INSERT INTO Costumers
                            VALUES(@costumerId, @costumerName, @costumerPhone, @costumerAddress, @costumerEmail)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@costumerId", p_costumer.CostumerId);
            command.Parameters.AddWithValue("@costumerName", p_costumer.Name);
            command.Parameters.AddWithValue("@costumerPhone", p_costumer.Phone);
            command.Parameters.AddWithValue("@costumerAddress", p_costumer.Address);
            command.Parameters.AddWithValue("@costumerEmail", p_costumer.Email);

            command.ExecuteNonQuery();

        }

        return p_costumer;
    }

    public void addOrder(Orders p_order)
    {
        string sqlQuery = @"INSERT INTO Orders
                            VALUES(@orderNumber, @costumerId, @storeNumber, @orderTotal, @dateStamp)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderNumber", p_order.OrderNumber);
            command.Parameters.AddWithValue("@costumerId", p_order.CostumerId);
            command.Parameters.AddWithValue("@storeNumber", p_order.StoreNumber);
            command.Parameters.AddWithValue("@orderTotal", p_order.OrderTotal);
            command.Parameters.AddWithValue("@dateStamp", p_order.DateCreated);

            command.ExecuteNonQuery();

        }
        
    }

    public void addLineItem(LineItems p_lineItem)
    {
        string sqlQuery = @"INSERT INTO LineItems
                            VALUES(@orderNumber, @productId, @quantity)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderNumber", p_lineItem.OrderNumber);
            command.Parameters.AddWithValue("@productId", p_lineItem.ProductId);
            command.Parameters.AddWithValue("@quantity", p_lineItem.Quantity);

            command.ExecuteNonQuery();

        }
    }

    public List<Costumer> ListOfCostumers()
    {
        List<Costumer> costumerList = new List<Costumer>();

        string sqlQuery = @"SELECT * FROM Costumers";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        { 
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerList.Add(new Costumer(){
                    CostumerId = reader.GetInt32(0), 
                    Name = reader.GetString(1),
                    Phone = reader.GetString(2),
                    Address = reader.GetString(3),
                    Email = reader.GetString(4)
                });
            }
        }

        return costumerList;
    }

    public List<Products> ListOfProducts()
    {
        List<Products> costumerList = new List<Products>();

        string sqlQuery = @"SELECT * FROM Products";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerList.Add(new Products(){
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    ProductPrice = reader.GetDouble(2),
                    ProductDescription = reader.GetString(3),
                    ProductCategory = reader.GetString(4)
                });
            }
        }

        return costumerList;
    }

    public List<StoreFront> ListOfStores()
    {
        List<StoreFront> storeList = new List<StoreFront>();

        string sqlQuery = @"SELECT * FROM Stores";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                storeList.Add(new StoreFront(){
                    StoreNumber = reader.GetInt32(0),
                    StoreName = reader.GetString(1),
                    StoreAddress = reader.GetString(2)
                });
            }
        }

        return storeList;
    }

    public List<Orders> ListOfCostumerOrders(int p_costumerId)
    {
        List<Orders> orderList = new List<Orders>();
        

        string sqlQuery = @"SELECT * FROM Orders o WHERE o.costumerId=@costumerId";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@costumerId", p_costumerId);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderList.Add(new Orders(){
                    OrderNumber = reader.GetInt32(0),
                    CostumerId = reader.GetInt32(1),
                    StoreNumber = reader.GetInt32(2),
                    OrderTotal = reader.GetDouble(3),
                    DateCreated = reader.GetDateTime(4)
                    
                });

                orderList.Last().OrderedItems = ListOfOrderProducts(orderList.Last().OrderNumber);
            }
        }


        return orderList;
    }

    public List<OrderProduct> ListOfOrderProducts(int p_orderNumber)
    {
        List<OrderProduct> orderProductsList = new List<OrderProduct>();

        string sqlQuery = @"SELECT * FROM LineItems l WHERE l.orderNumber=@orderNumber";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderNumber", p_orderNumber);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderProductsList.Add(new OrderProduct(){
                    //OrderNumber = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    ProductQuantity = reader.GetInt32(2),
                });

                Products currProduct = FindProduct(orderProductsList.Last().ProductId);

                orderProductsList.Last().ProductCost = currProduct.ProductPrice;
                orderProductsList.Last().ProductDescription = currProduct.ProductDescription;
                orderProductsList.Last().ProductName = currProduct.ProductName;
                orderProductsList.Last().TotalCost = orderProductsList.Last().ProductQuantity*currProduct.ProductPrice;
            }
        }

        return orderProductsList;
    }

    public Products FindProduct(int p_productId)
    {
        Products currProdcut = new Products();

        string sqlQuery = @"SELECT * FROM Products p WHERE p.productId=@productId";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@productId", p_productId);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                currProdcut = new Products(){
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    ProductPrice = reader.GetDouble(2),
                    ProductDescription = reader.GetString(3),
                    ProductCategory = reader.GetString(4)
                };
            }
        }

        return currProdcut;
    }

    public List<Orders> ListOfStoreFrontOrders(int p_storeNumber)
    {
        List<Orders> orderList = new List<Orders>();

        string sqlQuery = @"SELECT * FROM Orders WHERE storeNumber=@storeNumber";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@storeNumber", p_storeNumber);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderList.Add(new Orders(){
                    OrderNumber = reader.GetInt32(0),
                    CostumerId = reader.GetInt32(1),
                    StoreNumber = reader.GetInt32(2),
                    OrderTotal = reader.GetDouble(3),
                    DateCreated = reader.GetDateTime(4)
                });

                orderList.Last().OrderedItems = ListOfOrderProducts(orderList.Last().OrderNumber);
            }

            
        }

        return orderList;
    }

    public List<StoreInventory> ListInventory(int p_storeNumber)
    {
        List<StoreInventory> inventoryList = new List<StoreInventory>();

        string sqlQuery = @"SELECT s.storeNumber, p.productId, p.productName, p.productDescription, s.quantity
             FROM Products p INNER JOIN StoreInventory s ON p.productId=s.productId WHERE s.storeNumber=@orderNumber";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            command.Parameters.AddWithValue("@orderNumber", p_storeNumber);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                inventoryList.Add(new StoreInventory(){
                    StoreNumber = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    ProductName = reader.GetString(2),
                    ProductDescription = reader.GetString(3),
                    Quantity= reader.GetInt32(4)
                });
            }
        }

        return inventoryList;

    }

    public List<StoreInventory> addInventory(List<StoreInventory> p_stock)
    {
        List<StoreInventory> addedInventoryList = new List<StoreInventory>();
        StoreInventory currItem = new StoreInventory();

        string sqlQuery = "";
        
        foreach (var item in p_stock)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                sqlQuery = @"IF (NOT EXISTS(SELECT * FROM StoreInventory WHERE storeNumber=@storeNumber AND productId=@productId))
                            BEGIN INSERT INTO StoreInventory VALUES(@storeNumber, @productId, @quantity)
                            END ELSE BEGIN UPDATE StoreInventory SET quantity = @quantity WHERE storeNumber=@storeNumber AND productId=@productId END";

                SqlCommand command = new SqlCommand(sqlQuery, conn);

                command.Parameters.AddWithValue("@storeNumber", item.StoreNumber);
                command.Parameters.AddWithValue("@productId", item.ProductId);
                command.Parameters.AddWithValue("@quantity", item.Quantity);

                command.ExecuteNonQuery();

                currItem.StoreNumber = item.StoreNumber;
                currItem.ProductId = item.ProductId;
                currItem.Quantity = item.Quantity;
                currItem.ProductName = item.ProductName;
                currItem.ProductDescription = item.ProductDescription;

                addedInventoryList.Add(currItem);

            }
        }

        return addedInventoryList;

    }

    public void subtractInventory(List<StoreInventory> p_products)
    {
        string sqlQuery = "";

        foreach (var item in p_products)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    sqlQuery = @"UPDATE StoreInventory SET quantity = quantity - @quantity WHERE storeNumber=@storeNumber AND productId=@productId";

                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    command.Parameters.AddWithValue("@quantity", item.Quantity);
                    command.Parameters.AddWithValue("@storeNumber", item.StoreNumber);
                    command.Parameters.AddWithValue("@productId", item.ProductId);
                    

                    command.ExecuteNonQuery();

                }
        }

    }

    public int createCostumerId()
    {
        int costumerId = 1000;

        string sqlQuery = @"SELECT count(*) FROM Costumers";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                costumerId += reader.GetInt32(0)*10;
            }
        }

        return costumerId;
    }

    public int createOrderId()
    {
        int orderNumber = 300000;

        string sqlQuery = @"SELECT count(*) FROM Orders";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderNumber += reader.GetInt32(0)*10+10;
            }
        }


        return orderNumber;
    }

    public List<Manager> GetManagerList()
    {
        List<Manager> managerList = new List<Manager>();

        string sqlQuery = @"SELECT * FROM Manager";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                managerList.Add(new Manager(){
                    ManagerId = reader.GetInt32(0),
                    ManagerPassword = reader.GetInt32(1),
                });
            }
        }

        return managerList;

    }

    public List<Employee> GetEmployeeList()
    {
        List<Employee> employeeList = new List<Employee>();

        string sqlQuery = @"SELECT * FROM Employee";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            
            SqlCommand command = new SqlCommand(sqlQuery, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                employeeList.Add(new Employee(){
                    EmployeeId = reader.GetInt32(0),
                    EmployeePassword = reader.GetInt32(1),
                });
            }
        }

        return employeeList;

    }
}