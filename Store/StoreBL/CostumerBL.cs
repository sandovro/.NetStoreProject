using StoreModel;
using StoreDL;

namespace StoreBL;

public class CostumerBL : ICostumerBL
{
    private IRepository _repo;
    public CostumerBL(IRepository p_repo)
    {
        _repo = p_repo;
    }

    public Costumer AddCostumer(Costumer p_costumer)
    {
        p_costumer.CostumerId = CreateCostumerId();
        return _repo.AddCostumer(p_costumer);
    }

    public List<Costumer> GetAllCostumers()
    {
        return _repo.ListOfCostumers();
    }

    public List<Costumer> FindCostumer(int p_costumerId)
    {
        List<Costumer> costumerList = _repo.ListOfCostumers();

        return costumerList
                        .Where(Costumer => Costumer.CostumerId.Equals(p_costumerId)) //Where method is designed to filter a collection based on a condition
                        .ToList();


        // foreach (var curr in costumerList)
        // {
        //     // If costumer exists in database return true and object
        //     if (curr.CostumerId == p_costumerId)
        //         return curr;
        // }

        // Costumer empty = new Costumer();
        // return empty;
    }

    public int ProcessOrder(List<Products> p_products, int p_costumerId, int p_storeNumber)
    {
        List<StoreInventory> _storeInventoryList = new List<StoreInventory>();

        StoreInventory _storeInventoryItem = new StoreInventory();
        LineItems _lineItem = new LineItems();
        Orders _newOrder = new Orders();
        double _orderTotal = 0.0;
        int _orderNumber = CreateOrderId();

        foreach (var item in p_products)
        {
            _orderTotal += (item.ProductPrice*item.ProductQuantity);

            _storeInventoryItem.StoreNumber = p_storeNumber;
            _storeInventoryItem.ProductId = item.ProductId;
            _storeInventoryItem.Quantity = item.ProductQuantity;

            _storeInventoryList.Add(_storeInventoryItem);
        }

        _repo.subtractInventory(_storeInventoryList);

        _newOrder.OrderNumber = _orderNumber;
        _newOrder.CostumerId = p_costumerId;
        _newOrder.StoreNumber = p_storeNumber;
        _newOrder.OrderTotal = _orderTotal;
        _newOrder.DateCreated = DateTime.Now;

        _repo.addOrder(_newOrder);
        

        foreach (var item in p_products)
        {
            _lineItem.OrderNumber = _orderNumber; 
            _lineItem.ProductId = item.ProductId;
            _lineItem.Quantity = item.ProductQuantity;

            _repo.addLineItem(_lineItem);
        }
        
        return p_costumerId;
    }

    public List<Orders> OrderHistory(int p_costumerId, string p_orderBy)
    {
        List<Orders> orderList = _repo.ListOfCostumerOrders(p_costumerId);
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

    public int CreateCostumerId()
    {
        return _repo.createCostumerId();
    }

    public int CreateOrderId()
    {
        return _repo.createOrderId();
    }
}   
