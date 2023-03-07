namespace StoreUI;

public class MainMenu : IMenu
{
    public void ShowMenu()
    {
        Console.WriteLine("===============================================================");
        Console.WriteLine("                  Store Management System 2.0");
        Console.WriteLine("===============================================================");
        Console.WriteLine();
        Console.WriteLine("                       -- Main Menu --");
        Console.WriteLine("");
        Console.WriteLine("                What would you like to do today?\n");
        Console.WriteLine("                    <1> Add Costumer");
        Console.WriteLine("                    <2> Search for Costumer");
        Console.WriteLine("                    <3> View Store Inventory");
        Console.WriteLine("                    <4> Place Order");
        Console.WriteLine("                    <5> View Order History");
        Console.WriteLine("                    <6> Replenish Inventory");
        Console.WriteLine("                    <0> Exit\n\n");
        Console.Write(" Choice: ");
    }

    public string UserPick()
    {
        string pickedChoice = Console.ReadLine();

        switch (pickedChoice)
        {
            case "0":
                return "Exit";
            case "1":
                return "AddCostumer";
            case "2":
                return "SearchCostumer";
            case "3":
                return "ViewStoreInventory";
            case "4":
                return "PlaceOrder";
            case "5":
                return "OrderHistory";
            case "6":
                return "ReplenishInventory";
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "MainMenu";
                
        }
    }
}
