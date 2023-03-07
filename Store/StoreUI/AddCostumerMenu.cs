using StoreModel;
using StoreBL;

namespace StoreUI;

public class AddCostumerMenu : IMenu
{
    private static Costumer _newCostumer = new Costumer();

    private ICostumerBL _costumerBL;
    public AddCostumerMenu(ICostumerBL p_costumerBL)
    {
        _costumerBL = p_costumerBL;
    }
    public void ShowMenu()
    {
        Console.WriteLine("===============================================================");
        Console.WriteLine("                  Store Management System 2.0");
        Console.WriteLine("===============================================================");
        Console.WriteLine();
        Console.WriteLine("                       -- Add Costumer --");
        Console.WriteLine("");
        Console.WriteLine("                 Enter Costumer Information\n");
        Console.WriteLine($"                    <1> Name: {_newCostumer.Name}");
        Console.WriteLine($"                    <2> Phone: {_newCostumer.Phone}");
        Console.WriteLine($"                    <3> Address: {_newCostumer.Address}");
        Console.WriteLine($"                    <4> Email: {_newCostumer.Email}");
        Console.WriteLine("                    <5> Add Costumer and Return to Main Menu");
        Console.WriteLine("                    <0> Return to Main Menu (Changes won't be saved)\n\n");
        Console.Write(" Choice: ");
    }

    public string UserPick()
    {
        string pickedChoice = Console.ReadLine();

        switch (pickedChoice)
        {
            case "0":
                return "MainMenu";
            case "1":
                Console.WriteLine("");
                Console.WriteLine("Please Enter Costumer Name:");
                _newCostumer.Name = Console.ReadLine();
                return "AddCostumer";
            case "2":
                Console.WriteLine("");
                Console.WriteLine("Please Enter Costumer Phone Number");
                _newCostumer.Phone = Console.ReadLine();
                return "AddCostumer";
            case "3":
                Console.WriteLine("");
                Console.WriteLine("Please Enter Costumer Address");
                _newCostumer.Address = Console.ReadLine();
                return "AddCostumer";
            case "4":
                Console.WriteLine("");
                Console.WriteLine("Please Enter Costumer Email");
                _newCostumer.Email = Console.ReadLine();
                return "AddCostumer";
            case "5":
                bool proceed = processInput();
                if (proceed)
                {
                    _newCostumer = new Costumer();
                    Log.Information($"User addded costumer {_newCostumer.ToString}");
                    return "MainMenu";
                }
                else
                    return "AddCostumer";
            default:
                Console.WriteLine("");
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "AddCostumer";
        }
    }

    public bool processInput()
    {
        if (_newCostumer.Name!=".Name" && _newCostumer.Phone!=".Phone" && _newCostumer.Address!=".Address" && _newCostumer.Email !=".Email")
        {
            
            _newCostumer.CostumerId = _costumerBL.createCostumerId();
            Log.Information($"Program created costumerId {_newCostumer.addToOrder}");
            _costumerBL.AddCostumer(_newCostumer);
            Log.Information($"User succesfully added costumer {_newCostumer.CostumerId} to database");
            Console.WriteLine("");
            Console.WriteLine($"Costumer {_newCostumer.Name} has been succesfully added to database");
            Console.WriteLine("Press ENTER to go back to Main Menu");
            Console.ReadLine();
            return true;
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Please update every costumer field before saving");
            Console.WriteLine("Press ENTER to go back and finish");
            Console.ReadLine();
            return false;
        }
    }
}
