global using Serilog;

using StoreUI;
using StoreBL;
using StoreDL;
using Microsoft.Extensions.Configuration;

// Initializing program logging for debugging
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/debuglog.txt") //We configure our logger to save in this file
    .CreateLogger();

// Getting connection string from json file
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appSettings.json")
    .Build();

string _connectionString = configuration.GetConnectionString("StoreDatabase");

bool repeat = true;
IMenu menu = new MainMenu();

int storeNumber = 0;
while(repeat)
{
    Console.Clear();
    menu.ShowMenu();
    string choice = menu.UserPick();
    

    switch (choice)
    {
        case "Exit":
            Log.Information("User exited program");
            Log.CloseAndFlush();
            repeat = false;
            break;
        case "MainMenu":
            Log.Information("User entered main menu");
            menu = new MainMenu();
            break;
        case "AddCostumer":
            Log.Information("User selected AddCostumer menu");
            menu = new AddCostumerMenu(new CostumerBL(new SQLRepository(_connectionString)));
            break;
        case "SearchCostumer":
            Log.Information("User selected SearchCostumer menu");
            menu = new SearchCostumerMenu(new CostumerBL(new SQLRepository(_connectionString)));
            break;
        case "PlaceOrder":
            Log.Information("User went into PlaceOrder menu");
            menu = new PlaceOrderMenu(new CostumerBL(new SQLRepository(_connectionString)), new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "ViewStoreInventory":
            Log.Information("User selected ViewStoreFront inventory menu");
            menu = new ViewStoreInventoryMenu(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "OrderHistory":
            Log.Information("User went itno OrderHistory menu");
            menu = new ViewOrderHistoryMenu(new CostumerBL(new SQLRepository(_connectionString)));
            break;
        case "ReplenishInventory":
            Log.Information("User went into ReplenishINventory menu");
            menu = new ReplenishInventoryMenu(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        default:
            Log.Information("Program reached dafault case in switch (an error occured). Returning user to main menu");
            Console.WriteLine("An error has occured while processing your request");
            Console.WriteLine("Press ENTER to return to main menu");
            Console.ReadLine();
            menu = new MainMenu();
            break;
    }
}