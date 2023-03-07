using StoreModel;

namespace StoreBL;

public interface IStoreFrontBL
{
    /// <summary>
    /// This function processes the request to see if a store exists in the database.
    /// If it does it returns the store's details
    /// </summary>
    /// <param name="p_storeNumber"></param>
    /// <returns></returns>
    (StoreFront, bool) findStore(StoreFront p_storeNumber);

    /// <summary>
    /// This function processes the request to find a product in the database
    /// </summary>
    /// <param name="p_product"></param>
    /// <returns></returns>
    (Products, bool) findProduct(Products p_product);

    /// <summary>
    /// This function processes the request to list all inventory for a certain store
    /// </summary>
    /// <param name="p_storeNumber"></param>
    /// <returns></returns>
    List<StoreInventory> listInventory(int p_storeNumber);

    /// <summary>
    /// This function processes the request to list all products in the database
    /// </summary>
    /// <returns></returns>
    List<Products> listOfProducts();

    /// <summary>
    /// This function processes the request to subtract inventory form the database for a certrain store
    /// </summary>
    /// <param name="p_stock"></param>
    void subtractInventory(List<StoreInventory> p_stock);

    /// <summary>
    /// This function processes the request to add inventory to the database for a certain store.
    /// The process has to be done by a manger and a manager's id and passcode is required.
    /// </summary>
    /// <param name="p_storeInventory"></param>
    /// <param name="p_managerId"></param>
    /// <param name="p_managerCode"></param>
    /// <returns></returns>
    List<StoreInventory> addInventory(List<StoreInventory> p_storeInventory, int p_managerId, int p_managerPassword);

    /// <summary>
    /// This function processes the request to list all orders placed at a certain store
    /// THe list of orders is sorted by either data or total
    /// </summary>
    /// <param name="p_costumerId"></param>
    /// <param name="p_orderBy"></param>
    /// <returns></returns>
    List<Orders> orderHistory(int p_costumerId, string p_orderBy);

    /// <summary>
    /// This functions processes the request to get all employee credentials to check if employee is authorized
    /// </summary>
    /// <param name="p_employeeId"></param>
    /// <param name="p_employeePassword"></param>
    /// <returns></returns>
    bool VerifyEmployee(int p_employeeId, int p_employeePassword);

    /// <summary>
    /// This function processes the request to get all manager credentials to check if manager is authorized
    /// </summary>
    /// <param name="p_managerId"></param>
    /// <param name="p_managerPassword"></param>
    /// <returns></returns>
    bool VerifyManager(int p_managerId, int p_managerPassword);

}