using StoreModel;

namespace StoreBL;

public interface ICostumerBL
{
    /// <summary>
    /// This function processes the request to add a costumer to the database
    /// </summary>
    /// <param name="p_costumer"></param>
    /// <returns></returns>
    Costumer AddCostumer(Costumer p_costumer);

    /// <summary>
    /// This method gets all costumers in the database
    /// </summary>
    /// <returns></returns>

    List<Costumer> GetAllCostumers();

    /// <summary>
    /// This function processes the request to find a costumer in the database
    /// </summary>
    /// <param name="p_costumerId"></param>
    /// <returns></returns>
    List<Costumer> FindCostumer(int p_costumerId);

    /// <summary>
    /// This function processes a new order
    /// </summary>
    /// <param name="p_products"></param>
    /// <param name="p_costumerId"></param>
    /// <param name="p_storeNumber"></param>
    /// <returns></returns>
    int ProcessOrder(List<Products> p_products, int p_costumerId, int p_storeNumber);

    /// <summary>
    /// This function processes the request to see all orders placed for a costumer
    /// The list of orders is sorted by either date or total
    /// </summary>
    /// <param name="p_costumerId"></param>
    /// <param name="p_orderBy"></param>
    /// <returns></returns>
    List<Orders> OrderHistory(int p_costumerId, string p_orderBy);
    
    /// <summary>
    /// This function creates the costumer ID based on previous IDs already in the database
    /// </summary>
    /// <returns></returns>
    int CreateCostumerId();

    /// <summary>
    /// This function creates an order ID based on previous orders in the database
    /// </summary>
    /// <returns></returns>

    int CreateOrderId();

}
