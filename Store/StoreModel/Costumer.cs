namespace StoreModel;
public class Costumer
{
    public int CostumerId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public List<Orders> _orders;
    

    public Costumer()
    {
        CostumerId = 0;
        Name = ".Name";
        Phone = ".Phone";
        Address = ".Address";
        Email = ".Email";
        _orders = new List<Orders>();
    }

    // public void addToOrder(Orders p_product)
    // {
    //     _orders.Add(p_product);
    // }

    // public override string ToString()
    // {
    //     return $"ID: {CostumerId}\nName: {Name}\nPhone Number: {Phone}\nAddress: {Address}\nEmail: {Email}";
    // }
    
}