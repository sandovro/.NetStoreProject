// using StoreModel;
// using StoreBL;

// namespace StoreUI;
// public class SearchCostumerMenu : IMenu
// {
//     private static Costumer _newCostumer = new Costumer();

//     private ICostumerBL _costumerBL;
//     public SearchCostumerMenu(ICostumerBL p_costumerBL)
//     {
//         _costumerBL = p_costumerBL;
//     }
//     public void ShowMenu()
//     {
//         Console.WriteLine("===============================================================");
//         Console.WriteLine("                  Store Management System 2.0");
//         Console.WriteLine("===============================================================");
//         Console.WriteLine();
//         Console.WriteLine("                       -- Costumer Search --");
//         Console.WriteLine("");
//         Console.WriteLine("                 Enter the Following Costumer Information to do a Search\n");
//         Console.WriteLine($"                    <3> Name: {_newCostumer.Name}");
//         Console.WriteLine($"                    <2> Phone: {_newCostumer.Phone}");
//         Console.WriteLine("                    <1> Search");
//         Console.WriteLine("                    <0> Return to Main Menu (Changes won't be saved)\n\n");
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
//                 bool proceed = processInput();
//                 if (proceed)
//                 {
//                     _newCostumer = new Costumer();
//                     return "MainMenu";
//                 }
//                 else
//                     return "SearchCostumer";
//             case "2":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Costumer Phone Number");
//                 _newCostumer.Phone = Console.ReadLine();
//                 return "SearchCostumer";
//             case "3":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Costumer Name:");
//                 _newCostumer.Name = Console.ReadLine();
//                 return "SearchCostumer";
//             default:
//                 Console.WriteLine("");
//                 Console.WriteLine("You Have Entered An Invalid Choice");
//                 Console.WriteLine("Press ENTER to try again");
//                 Console.ReadLine();
//                 return "SearchCostumerMenu";
//         }
//     }

//     public bool processInput()
//     {
//         if (_newCostumer.Name!=".Name" && _newCostumer.Phone!=".Phone")
//         {
//             Log.Information($"User is trying to looked up costumer {_newCostumer.Name}{_newCostumer.Phone}");
//             (Costumer _curr, bool found) = _costumerBL.findCostumer(_newCostumer);
//             if (found)
//             {
//                 Log.Information($"User succsefully looked up costumer {_newCostumer.CostumerId}");
//                 Console.WriteLine("");
//                 Console.WriteLine("Costumer was successfully found in the Database");
//                 Console.WriteLine(_curr.ToString());
                
//             }
//             else
//             {
//                 Console.WriteLine("");
//                 Console.WriteLine("Costumer Was Not Found in the Databse");
//                 Console.WriteLine("Add costumer to Database if Needed");
//             }

//             Console.WriteLine("Press ENTER to go back to Main Menu");
//             Console.ReadLine();
//             return true;
//         }
//         else
//         {
//             Console.WriteLine("");
//             Console.WriteLine("Please enter costumer information into every field to search");
//             Console.WriteLine("Press ENTER to go back and finish");
//             Console.ReadLine();
//             return false;
//         }
//     }
// }
