namespace StoreModel;
public class LineItems
{
    public int OrderNumber { get; set; } // First foreign key
    public int ProductId { get; set; } // Second foreign key
    public int Quantity { get; set; }
    public double ProductTotal { get; set; }

    public LineItems()
    {
        OrderNumber = 0;
        ProductId = 0;
        Quantity = 0;
    }
}