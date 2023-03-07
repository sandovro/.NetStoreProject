using StoreModel;
using System.Text.Json;

namespace StoreDL;
public class Repository
{
    //private static List<Costumer> _costumerList = new List<Costumer>();
    //private List<StoreFront> _storeList = new List<StoreFront>();
    //private static List<Products> _productsList = new List<Products>(); 

    private string _filepath = "../StoreDL/Database/";
    private string _jsonstring;

    public Costumer AddCostumer(Costumer p_costumer)
    {
        List<Costumer> _costumerList = ListOfCostumers();
        _costumerList.Add(p_costumer);

        string path = _filepath + "Costumer.json";
        _jsonstring = JsonSerializer.Serialize(_costumerList, new JsonSerializerOptions {WriteIndented = true});

        File.WriteAllText(path, _jsonstring);

        return p_costumer;
    }

    public List<Costumer> ListOfCostumers(){
        // Converting JSON to Object
        string jsonString = File.ReadAllText(_filepath + "Costumer.json");
        
        // Load Objects onto new list
        List<Costumer> _newCostumerList = JsonSerializer.Deserialize<List<Costumer>>(jsonString);
        return _newCostumerList;
    }

    public List<Products> ListOfProducts(){
        // Converting JSON to Object
        string jsonString = File.ReadAllText(_filepath + "Products.json");
        
        // Load Objects onto new list
        List<Products> _newProductsList = JsonSerializer.Deserialize<List<Products>>(jsonString);
        return _newProductsList;
    }

    public List<StoreFront> ListOfStores(){
        // Converting JSON to Object
        string jsonString = File.ReadAllText(_filepath + "Stores.json");
        
        // Load Objects onto new list
        List<StoreFront> _newStoresList = JsonSerializer.Deserialize<List<StoreFront>>(jsonString);
        return _newStoresList;
    }

    public void addOrder(Costumer p_costumer, Orders p_order)
    {
        // Get file path to costumer json file
        string path = _filepath + "Costumer.json";

        // Read everything in the file into a string
        string jsonString = File.ReadAllText(path);
        
        // Load all the data from the json file into a costumer list
        List<Costumer> _newCostumerList = JsonSerializer.Deserialize<List<Costumer>>(jsonString);

        for (int i = 0; i < _newCostumerList.Count; i++)
        {
            if (_newCostumerList[i].Name == p_costumer.Name && _newCostumerList[i].Phone == p_costumer.Phone)
                _newCostumerList[i]._orders.Add(p_order);
        }

        // Turn the whole list into a json string
        _jsonstring = JsonSerializer.Serialize(_newCostumerList);

        // Write all the data from the json string into the file
        File.WriteAllText(path, _jsonstring);
    }

    public Products AddProduct(Products p_product)
    {
        List<Products> _productList = ListOfProducts();
        _productList.Add(p_product);

        string path = _filepath + "Products.json";
        _jsonstring = JsonSerializer.Serialize(_productList, new JsonSerializerOptions {WriteIndented = true});

        File.WriteAllText(path, _jsonstring);

        return p_product;
    }

    public List<Products> ListInventory(int p_storeNumber)
    {
        throw new NotImplementedException();
    }

    public List<Orders> ListOfOrders(int p_costumerId)
    {
        throw new NotImplementedException();
    }

    public void subtractInventory(List<StoreInventory> p_stock)
    {
        throw new NotImplementedException();
    }

    public void addInventory(List<StoreInventory> p_stock)
    {
        throw new NotImplementedException();
    }

    public void addOrder(List<LineItems> p_lineItemsList, Orders p_order)
    {
        throw new NotImplementedException();
    }

    public int createCostumerId()
    {
        throw new NotImplementedException();
    }

}