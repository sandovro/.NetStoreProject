// using StoreBL;
// using StoreModel;

// namespace StoreUI;

// class ViewOrderHistoryMenu : IMenu
// {
//     private static Costumer _newCostumer = new Costumer();

//     private ICostumerBL _costumerBL;
//     public ViewOrderHistoryMenu(ICostumerBL p_costumerBL)
//     {
//         _costumerBL = p_costumerBL;
//     }
//     public void ShowMenu()
//     {
//         Console.WriteLine("===============================================================");
//         Console.WriteLine("                  Store Management System 2.0");
//         Console.WriteLine("===============================================================");
//         Console.WriteLine();
//         Console.WriteLine("                       -- Order History --");
//         Console.WriteLine("");
//         Console.WriteLine("                  Please Enter Required Information\n");
//         Console.WriteLine($"                    <3> Name: {_newCostumer.Name}");
//         Console.WriteLine($"                    <2> Phone: {_newCostumer.Phone}");
//         Console.WriteLine("                    <1> View Order History");
//         Console.WriteLine("                    <0> Main Menu\n\n");
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
//                 return "MainMenu";
//             case "2":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Costumer Phone Number");
//                 _newCostumer.Phone = Console.ReadLine();
//                 return "OrderHistory";
//             case "3":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Costumer Name:");
//                 _newCostumer.Name = Console.ReadLine();
//                 return "OrderHistory";
//             default:
//                 Console.WriteLine("");
//                 Console.WriteLine("You Have Entered An Invalid Choice");
//                 Console.WriteLine("Press ENTER to try again");
//                 Console.ReadLine();
//                 return "OrderHistory";
//         }
        
//     }

//     public void processInput()
//     {
//         Log.Information($"User is trying to looked up order history for costumer {_newCostumer.Name}{_newCostumer.Phone}");
//         (_newCostumer, bool found) = _costumerBL.findCostumer(_newCostumer);
//         if (found)
//         {
//             Log.Information($"User succesfully looked up order history for costumer {_newCostumer.CostumerId}");
//             List<Orders> orderList = _costumerBL.orderHistory(_newCostumer.CostumerId);
//             int i = 1;

//             foreach (var item in orderList)
//             {
//                 Console.WriteLine();
//                 Console.WriteLine($"Order {i}");
//                 Console.WriteLine(item.ToString());
//                 Console.WriteLine();
//             }
//             Console.WriteLine("Press ENTER to continue");
//             Console.ReadLine();
//         }
//         else
//         {
//             _newCostumer = new Costumer();
//             Console.WriteLine("Costumer Doesn't Exist in Database");
//             Console.WriteLine("Press ENTER to go back and try again");
//             Console.ReadLine();
//         }
//     }
// }