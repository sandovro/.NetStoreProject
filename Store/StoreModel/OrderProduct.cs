namespace StoreModel;

public class OrderProduct
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public double ProductCost { get; set; }
    public int ProductQuantity { get; set; }
    public double TotalCost { get; set; }
}
