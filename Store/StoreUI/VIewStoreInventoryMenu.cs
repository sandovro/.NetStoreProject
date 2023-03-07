// using StoreBL;
// using StoreModel;

// namespace StoreUI;

// public class ViewStoreInventoryMenu : IMenu
// {
//     private static StoreFront _newStore = new StoreFront();
//     private List<StoreInventory> _listOfInventory = new List<StoreInventory>();
//     private bool storeFound = true;
//     private bool readyForOrder = false;

//     private IStoreFrontBL _storeFrontBL;
//     public ViewStoreInventoryMenu(IStoreFrontBL p_storeFrontBL)
//     {
//         _storeFrontBL = p_storeFrontBL;
//     }


//     public void ShowMenu()
//     {
//         Console.WriteLine("===============================================================");
//         Console.WriteLine("                  Store Management System 2.0");
//         Console.WriteLine("===============================================================");
//         Console.WriteLine();
//         Console.WriteLine("                       -- View Inventory --");
//         Console.WriteLine("");
//         Console.WriteLine("                 Please Fill In the Following Store Information\n");
//         Console.WriteLine($"                    <3> Store Number: {_newStore.StoreNumber}");
//         //Console.WriteLine("<2> Start a Costumer Purchse From Selected Store");
//         Console.WriteLine("                    <1> Search For Store and List Inventory");
//         Console.WriteLine("                    <0> Return to Main Menu\n\n");
//         Console.Write(" Choice: ");
//     }

//     public string UserPick()
//     {
//         string choice = Console.ReadLine();

//         switch (choice)
//         {
//             case "0":
//                 return "MainMenu";
//             case "1":
//                 processInput();
//                 return "ViewStoreInventory";
//             // case "2":
//             //     if (readyForOrder)
//             //     {
//             //         storeNumber = _newStore.StoreNumber;
//             //         return "PlaceOrder";
//             //     }
//             //     else
//             //     {
//             //         Console.WriteLine("Please do a search for store before trying to place an order");
//             //         Console.WriteLine("Press ENTER to continue");
//             //         Console.ReadLine();
//             //         return "ViewStoreInventory";
//             //     }
                
//             case "3":
                   
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Store Number");
//                 _newStore.StoreNumber = Convert.ToInt32(Console.ReadLine());
//                 Log.Information($"User entered store number {_newStore.StoreNumber}"); 
//                 return "ViewStoreInventory";
//             default:
//                 Console.WriteLine("");
//                 Console.WriteLine("You Have Entered an Invalid Choice");
//                 Console.WriteLine("Press ENTER to try again");
//                 Console.ReadLine();
//                 return "ViewStoreInventory";
//         }
            
//     }

//     public void processInput()
//     {
//         if (_newStore.StoreNumber!=0)
//         {
//             (StoreFront _curr, bool found) = _storeFrontBL.findStore(_newStore);

//             if(found)
//             {
//                 Log.Information($"Store Number: {_newStore.StoreNumber} was found in the database");
//                 _listOfInventory = _storeFrontBL.listInventory(_curr.StoreNumber);
//                 Console.WriteLine("");
//                 foreach (var item in _listOfInventory)
//                 {
//                     Console.WriteLine(item.ToString());
//                 }
                
//                 Console.WriteLine("Press ENTER to Continue");
//                 Console.ReadLine();
//             }
//             else
//             {
//                 Log.Information($"Store Number: {_newStore.StoreNumber} was not found in the database");
//                 Console.WriteLine("");
//                 Console.WriteLine("Store not found");
//                 Console.WriteLine("Information might be incorrect or Store doesn't exist");
//                 Console.WriteLine("Press ENTER to try again");
//                 Console.ReadLine();
//             }
//         }
//         else
//         {
//             Console.WriteLine("");
//             Console.WriteLine("Please Fill in All the Required Information to do a Search");
//             Console.WriteLine("Press ENTER to continue");
//             Console.ReadLine();
//         }
//     }
// }