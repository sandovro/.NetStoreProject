// using StoreModel;
// using StoreBL;

// namespace StoreUI;

// class ReplenishInventoryMenu : IMenu
// {
//     private static List<StoreInventory> _inventoryList = new List<StoreInventory>();
//     private static StoreFront _newStore =  new StoreFront();
//     private static StoreInventory _newItem = new StoreInventory();

//     private static bool _storeReady = false;
//     private static bool _inventoryReady = false;

//     private IStoreFrontBL _storeFrontBL;
//     public ReplenishInventoryMenu(IStoreFrontBL p_storeFrontBL)
//     {
//         _storeFrontBL = p_storeFrontBL;
//     }


//     public void ShowMenu()
//     {
//         Console.WriteLine("===============================================================");
//         Console.WriteLine("                  Store Management System 2.0");
//         Console.WriteLine("===============================================================");
//         Console.WriteLine();
//         Console.WriteLine("                    -- Replenish Inventory --");
//         Console.WriteLine("");
//         Console.WriteLine("                     Enter Store Information\n");
//         Console.WriteLine($"                    <3> Store Number: {_newStore.StoreNumber}");
//         Console.WriteLine("                    <2> Add Item and Quantity");
//         Console.WriteLine("                    <1> Finish Replenish Request");
//         Console.WriteLine("                    <0> Return to Main Menu Without Saving Changes\n\n");
//         Console.Write(" Choice: ");
        
//     }

//     public string UserPick()
//     {
//         string choice = Console.ReadLine();
//         switch (choice)
//         {
//             case "0":
//                 _inventoryList = new List<StoreInventory>();
//                 _newStore =  new StoreFront();
//                 _newItem = new StoreInventory();
//                 return "MainMenu";
//             case "1":
//                 if (_storeReady && _inventoryReady)
//                 {
//                     Log.Information($"User succesfully added inventory to store {_newStore.StoreNumber}");
//                     // call method and pass list
//                     _storeFrontBL.addInventory(_inventoryList);
//                     Console.WriteLine("");
//                     Console.WriteLine("Inventory has been succesfully updated");
//                     Console.WriteLine("Press ENTER to return to Main Menu");
//                     Console.ReadLine();
//                     return "MainMenu";
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please finish adding a store and inventory before placing order");
//                     Console.WriteLine("Press ENTER to continue");
//                     Console.ReadLine();
//                     return "ReplenishInventory";
//                 }
                
//             case "2":
//                 if (_storeReady)
//                 {
//                     // Get product information
//                     Console.WriteLine("");
//                     Console.WriteLine("Enter Item Number");
//                     _newItem.ProductId = Convert.ToInt32(Console.ReadLine());
//                     Console.WriteLine();
//                     Console.WriteLine("Enter Total Quantity (Current Quantity + New Inventory Quantity");
//                     _newItem.Quantity = Convert.ToInt32(Console.ReadLine());
                    
//                     Log.Information($"User entered product {_newItem.ProductId} with quantity {_newItem.ProductId} to replenish inventory for store {_newStore.StoreNumber}");


//                     _newItem.StoreNumber = _newStore.StoreNumber;
//                     // Add product to inventory list
//                     _inventoryList.Add(_newItem);
//                     Console.WriteLine("");
//                     Console.WriteLine("Item Added to Inventory Queue");
//                     Console.WriteLine("Press ENTER to Continue");
//                     Console.ReadLine();
//                 }
//                 else
//                 {
//                     Log.Information("User selected add item option before entering store details");
//                     Console.WriteLine("Please enter a store number before adding inventory");
//                     Console.WriteLine("Press ENTER to continue");
//                     Console.ReadLine();
//                 }
//                 return "ReplenishInventory";
//             case "3":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Store Number");
//                 _newStore.StoreNumber = Convert.ToInt32(Console.ReadLine());
//                 processInput();
//                 return "ReplenishInventory";
//             case "4":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Store Name");
//                 _newStore.StoreName = Console.ReadLine();
//                 return "ReplinishInventory";
//             default:
//                 Log.Information("User entered wrong option in replenish menu");
//                 Console.WriteLine("");
//                 Console.WriteLine("You Have Entered An Invalid Choice");
//                 Console.WriteLine("Press ENTER to try again");
//                 Console.ReadLine();
//                 return "ReplenishInventory";
//         }
        
//     }

//     public void processInput()
//     {
//         Log.Information($"User is trying to look up store {_newStore.StoreName} - {_newStore.StoreName} to replenish stock");
//         if (_newStore.StoreNumber != 0)
//         {
//             (_newStore, bool found ) = _storeFrontBL.findStore(_newStore);
//             if (!found)
//             {
                
//                 _newStore =  new StoreFront();
//                 Console.WriteLine("");
//                 Console.WriteLine("Store Not Found in Database");
//                 Console.WriteLine("Press ENTER to continue");
//                 Console.ReadLine();

//             }
//             Log.Information($"User succesfully looked up store {_newStore.StoreNumber} to replenish stock");
//             _storeReady = true;
//         }
//         else
//         {
//             _newStore =  new StoreFront();
//             Console.WriteLine("");
//             Console.WriteLine("Please Finish Filling in Store Details");
//             Console.WriteLine("Press ENTER to continue");
//             Console.ReadLine();
//         }
//     }
// }