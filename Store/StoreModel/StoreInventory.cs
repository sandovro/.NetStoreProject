namespace StoreModel;

public class StoreInventory
{
    public int StoreNumber { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int Quantity { get; set; }

    public StoreInventory()
    {
        StoreNumber = 0;
        ProductId = 0;
        ProductName = "";
        ProductDescription = "";
        Quantity = 0;
    }

    // public override string ToString()
    // {
    //     return $"ID: {ProductId} Name: {ProductName} Description: {ProductDescription} Quantity Available: {Quantity}";
    // }
    
}