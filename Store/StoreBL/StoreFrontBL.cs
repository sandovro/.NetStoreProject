using StoreModel;
using StoreDL;

namespace StoreBL;

public class StoreFrontBL : IStoreFrontBL
{
    private IRepository _repo;
    public StoreFrontBL(IRepository p_repo)
    {
        _repo = p_repo;
    }

    public (StoreFront, bool) findStore(StoreFront p_storeFront)
    {
        List<StoreFront> _storeFrontList = _repo.ListOfStores();

        foreach (var curr in _storeFrontList)
        {
            // If store exists in database return true and object
            if (curr.StoreNumber == p_storeFront.StoreNumber)
                return (curr, true);
        }
        //Console.WriteLine("costumer does not excist in database");

        StoreFront empty = new StoreFront();
        return (empty, false);
    }

    public (Products, bool) findProduct(Products p_product)
    {
        List<Products> _productList = _repo.ListOfProducts();

        foreach (var curr in _productList)
        {
            // If costumer exists in database return true and object
            if (curr.ProductId == p_product.ProductId)
                return (curr, true);
        }

        Products empty = new Products();
        return (empty, false);
    }

    public List<StoreInventory> listInventory(int p_storeNumber)
    {
        List<StoreInventory> inventoryList = _repo.ListInventory(p_storeNumber);

        return inventoryList;
    }

    public List<Products> listOfProducts()
    {
        List<Products> productList = _repo.ListOfProducts();

        return productList;
    }

    public void subtractInventory(List<StoreInventory> p_storeInventory)
    {
        _repo.subtractInventory(p_storeInventory);

    }

    public List<StoreInventory> addInventory(List<StoreInventory> p_storeInventory, int p_managerId, int p_managerPassword)
    {
        List<Manager> managerList = _repo.GetManagerList();

        foreach (var item in managerList)
        {
            if (item.ManagerId == p_managerId && item.ManagerPassword == p_managerPassword)
                return _repo.addInventory(p_storeInventory);
        }

        throw new Exception("Manager doesn't exist in database");

    }

    public List<Orders> orderHistory(int p_storeNumber, string p_orderBy)
    {
        List<Orders> orderList = _repo.ListOfStoreFrontOrders(p_storeNumber);
        List<Orders> sortedList = new List<Orders>();
        
        if (p_orderBy == "Date")
        {
            sortedList = orderList.OrderBy(x=>x.DateCreated).ToList();
        }
        else if(p_orderBy == "Total")
        {
            sortedList = orderList.OrderBy(x=>x.OrderTotal).ToList();
        }
        else if (p_orderBy == "None")
        {
            return orderList;
        }

    
        return sortedList;
    }

    public bool VerifyEmployee(int p_employeeId, int p_employeePassword)
    {
        List<Employee> employeeList = _repo.GetEmployeeList();
        List<Manager> managersList = _repo.GetManagerList();

        foreach (var item in employeeList)
        {
            if (item.EmployeeId == p_employeeId && item.EmployeePassword == p_employeePassword)
                return true;
        }

        foreach (var item in managersList)
        {
            if (item.ManagerId == p_employeeId && item.ManagerPassword == p_employeePassword)
                return true;
        }

        throw new Exception("Can't verify employee credentials");
        
    }

    public bool VerifyManager(int p_managerId, int p_managerPassword)
    {
        List<Manager> managerList = _repo.GetManagerList();

        foreach (var item in managerList)
        {
            if (item.ManagerId == p_managerId && item.ManagerPassword == p_managerPassword)
                return true;
        }

        throw new Exception("Can't verify manager credentials");
    }
}