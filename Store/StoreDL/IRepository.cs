using StoreModel;

namespace StoreDL;
public interface IRepository
{
    /// <summary>
    /// This function adds a costumer to the database
    /// </summary>
    /// <param name="p_costumer"></param>
    /// <returns></returns>
    Costumer AddCostumer(Costumer p_costumer);

    /// <summary>
    /// This functions reads all costumers in the database
    /// and inserts them into a list of type Costumer
    /// </summary>
    /// <returns></returns>
    List<Costumer> ListOfCostumers();

    /// <summary>
    /// This functions reads all products from the database
    /// and inserts them into a list of type Products
    /// </summary>
    /// <returns></returns>
    List<Products> ListOfProducts();

    /// <summary>
    /// This function reads all stores in the database
    /// and returns them in a list
    /// </summary>
    /// <returns></returns>
    List<StoreFront> ListOfStores();

    /// <summary>
    /// This functions reads all orders in the database for a specific costumer
    /// and returns them in a list
    /// </summary>
    /// <param name="p_costumerId"></param>
    /// <returns></returns>
    List<Orders> ListOfCostumerOrders(int p_costumerId);

    /// <summary>
    /// Gets all items that belong to an order
    /// </summary>
    /// <param name="p_orderNumber"></param>
    /// <returns></returns>
    List<OrderProduct> ListOfOrderProducts(int p_orderNumber);

    /// <summary>
    /// This functions reads all orders in the database for a specific store
    /// and returns them in a list
    /// </summary>
    /// <param name="p_storeNumber"></param>
    /// <returns></returns>
    List<Orders> ListOfStoreFrontOrders(int p_storeNumber);

    /// <summary>
    /// This function lists all the inventory for a store
    /// and puts it into a list
    /// </summary>
    /// <param name="p_storeNumber"></param>
    /// <returns></returns>
    List<StoreInventory> ListInventory(int p_storeNumber);

    /// <summary>
    /// This function adds an order to the database
    /// </summary>
    /// <param name="p_order"></param>
    void addOrder(Orders p_order);

    /// <summary>
    /// This function adds a LineItem to the database
    /// </summary>
    /// <param name="p_lineItem"></param>
    void addLineItem(LineItems p_lineItem);

    /// <summary>
    /// This function subtracts a given amount from the inventory 
    /// in the database for a given product that belongs to a given store
    /// </summary>
    /// <param name="p_products"></param>
    void subtractInventory(List<StoreInventory> p_products);

    /// <summary>
    /// This function adds inventory quantity in the datbase for a certain store
    /// </summary>
    /// <param name="p_stock"></param>
    /// <returns></returns>
    List<StoreInventory> addInventory(List<StoreInventory> p_stock);

    /// <summary>
    /// This function creates a costumerId. It does so by 
    /// reading how many costumers are already in the database
    /// </summary>
    /// <returns></returns>
    int createCostumerId();
    
    /// <summary>
    /// This function creates an orderId for a new order.
    /// It does so by counting how many orders are already in the database
    /// </summary>
    /// <returns></returns>
    int createOrderId();

    /// <summary>
    /// This function gets a list of all Managers and their credentials
    /// </summary>
    /// <returns></returns>
    List<Manager> GetManagerList();

    /// <summary>
    /// This function returns a list of all employees (non-manager)
    /// </summary>
    /// <returns></returns>
    List<Employee> GetEmployeeList();

}
