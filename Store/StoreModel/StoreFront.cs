namespace StoreModel;
public class StoreFront
{
    public int StoreNumber { get; set; }
    public string StoreName { get; set; }
    public string StoreAddress { get; set; }
    public List<StoreInventory> _inventoryList { get; set; }

    public StoreFront()
    {
        StoreNumber = 0;
        StoreName = ".StoreName";
        StoreAddress = ".StoreAddress";

    }

    // public override string ToString()
    // {
    //     return $"Name: {StoreName}\nAddress: {StoreAddress}";
    // }
    

}