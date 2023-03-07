// using StoreModel;
// using StoreBL;

// namespace StoreUI;

// public class PlaceOrderMenu : IMenu
// {
//     private static List<Products> _listOfProducts = new List<Products>();
//     private static List<StoreInventory> _listOfStock = new List<StoreInventory>();
//     private static Costumer _newCostumer = new Costumer();
//     private static StoreFront _newStoreFront = new StoreFront();
//     private static Products _currProduct = new Products();
//     private static StoreInventory _currStock = new StoreInventory();

//     private ICostumerBL _costumerBL;
//     private IStoreFrontBL _storeFrontBL;
//     public PlaceOrderMenu(ICostumerBL p_costumerBL, IStoreFrontBL p_storeFrontBL)
//     {
//         _costumerBL = p_costumerBL;
//         _storeFrontBL = p_storeFrontBL;
//     }

//     private static bool readyToProcess = false;
//     private static bool addedStore = false;
//     private static bool addedCostumer = false;
//     private static bool addedItem = false;
//     private static bool costumerFound = false;
//     public void ShowMenu()
//     {
//         Console.WriteLine("===============================================================");
//         Console.WriteLine("                  Store Management System 2.0");
//         Console.WriteLine("===============================================================");
//         Console.WriteLine();
//         Console.WriteLine("                       -- Place Order --");
//         Console.WriteLine("");

//         if(addedCostumer && !addedStore)
//         {
//             Console.WriteLine("Costumer:");
//             Console.WriteLine($"  {_newCostumer.Name}");
//             Console.WriteLine($"  {_newCostumer.Phone}");
//         }

//         else if(addedCostumer && addedStore)
//         {
//             Console.WriteLine("Costumer:                               Store:");
//             Console.WriteLine($"  {_newCostumer.Name}                                    {_newStoreFront.StoreNumber}");
//             Console.WriteLine($"  {_newCostumer.Phone}                            {_newStoreFront.StoreName}");
//             Console.WriteLine($"  {_newCostumer.Email}");
//         }

//         else if(!addedCostumer && addedStore)
//         {
//             Console.WriteLine("Store:");
//             Console.WriteLine($"  {_newStoreFront.StoreNumber}");
//             Console.WriteLine($"  {_newStoreFront.StoreName}");
//         }

//         if (addedItem)
//         {
//             Console.WriteLine("");
//             foreach (var item in _listOfProducts)
//             {
//                 Console.WriteLine("Qty   Item      Price");
//                 Console.WriteLine($" {item.ProductQuantity}     {item.ProductId}        {item.ProductPrice}");
//             }
//         }
//         Console.WriteLine("");
//         Console.WriteLine("                     Please Select an Option\n");
//         Console.WriteLine("                     <5> Select Store");
//         Console.WriteLine("                     <4> Select Costumer");
//         Console.WriteLine("                     <3> Add Items");
//         Console.WriteLine("                     <2> List Available Items");
//         Console.WriteLine("                     <1> Place Order");
//         Console.WriteLine("                     <0> Go Back to Main Menu\n\n");
//         Console.Write("Choice: ");
//     }

//     public string UserPick()
//     {
//         string pickedChoice = Console.ReadLine();

//         switch (pickedChoice)
//         {
//             case "0":
//                 resetState();
//                 return "MainMenu";
//             case"1":
//                 // Add list of products onto database
//                 if (addedStore && addedCostumer && addedItem)
//                     readyToProcess = true;
//                 if (readyToProcess){
//                     _costumerBL.processOrder(_listOfProducts, _newCostumer, _newStoreFront.StoreNumber);
//                     Log.Information($"User placed order for costumer {_newCostumer.CostumerId} from store {_newStoreFront.StoreNumber}");
//                     Console.WriteLine("");
//                     Console.WriteLine("Your Order Has Been Succesfully Placed");
//                     Console.WriteLine("Press ENTER To Go Back To Main Menu");
//                     Console.ReadLine();
//                     resetState();
//                 }
//                 else
//                 {
//                     Console.WriteLine("");
//                     Console.WriteLine("Please finish adding required order information");
//                     Console.WriteLine("Presente ENTER to continue");
//                     Console.ReadLine();
//                     return "PlaceOrder";
//                 }
//                 return"MainMenu";
//             case "2":
//                 if(addedStore)
//                 {
//                     _listOfStock = _storeFrontBL.listInventory(_newStoreFront.StoreNumber);
//                     Console.WriteLine("");
//                     foreach (var item in _listOfStock)
//                     {
//                         Console.WriteLine(item.ToString());
//                     }
//                     Console.WriteLine("");
//                     Console.WriteLine("Item Number Will be Required to Add Item to Cart");
//                     Console.WriteLine("Press ENTER to go back to Order Menu");
//                     Console.ReadLine();
//                     return "PlaceOrder";
//                 }
//                 else
//                 {
//                     Console.WriteLine("");
//                     Console.WriteLine("You have not added a store to your order");
//                     Console.WriteLine("Press ENTER to go back and add a store");
//                     Console.ReadLine();
//                     return "PlaceOrder";
//                 }
                
//             case "3":
//                 if (addedCostumer && addedStore)
//                 {
                    
//                     Console.WriteLine("");
//                     Console.WriteLine("Please Enter Item Number");
//                     _currProduct.ProductId = Convert.ToInt32(Console.ReadLine());
//                     Console.WriteLine("Please Enter Quantity");
//                     int _quantity = Convert.ToInt32(Console.ReadLine());
                    
//                     (_currProduct, bool found) = _storeFrontBL.findProduct(_currProduct);
//                     if (found)
//                     {
//                         _currProduct.ProductQuantity = _quantity;
//                         _currStock.ProductId = _currProduct.ProductId;
//                         _currStock.Quantity = _currProduct.ProductQuantity;
//                         _currStock.StoreNumber = _newStoreFront.StoreNumber;

//                         _listOfProducts.Add(_currProduct);
//                         _listOfStock.Add(_currStock);
                        
//                         Log.Information($"User succesfully added product {_currProduct.ProductId} with quantity {_currProduct.ProductQuantity} to order");
//                         Console.WriteLine("");
//                         Console.WriteLine($"Item Number: {_currProduct.ProductId} With Quantity {_currProduct.ProductQuantity}: Has Been Succesfully Added To Your Order");

//                         _currProduct = new Products();
//                         addedItem = true;

//                         Console.WriteLine("Press ENTER to Continue");
//                         Console.ReadLine();
//                         return "PlaceOrder";
//                     }
//                     else
//                     {
//                         Console.WriteLine("");
//                         Console.WriteLine("Invalid Product Information Entered");
//                         Console.WriteLine("Press ENTER to go back and try again");
//                         return "PlaceOrder";
//                     }
//                 }
//                 return "PlaceOrder";
//             case "4":
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Costumer Name");
//                 _newCostumer.Name = Console.ReadLine();
//                 Console.WriteLine("");
//                 Console.WriteLine("Please Enter Costumer Phone Number");
//                 _newCostumer.Phone = Console.ReadLine();
                
//                 (_newCostumer, costumerFound) = _costumerBL.findCostumer(_newCostumer);
//                 if (costumerFound)
//                 {
//                     addedCostumer = true;
//                     Console.WriteLine("");
//                     Console.WriteLine("Costumer Has Been Added To Order");
//                     Console.WriteLine("");
//                     Console.WriteLine("Costumer:");
//                     Console.WriteLine(_newCostumer.ToString());
//                     Console.WriteLine("");
//                     Console.WriteLine("Press ENTER To Go Back And Continue With Order");
//                     Console.ReadLine();
//                     return "PlaceOrder";
//                 }
//                 Console.WriteLine("Costumer Doesn't Exists in DataBase");
//                 Console.WriteLine("Press ENTER To Go Back to Order Menu");
//                 Console.ReadLine();
                
//                 return "PlaceOrder";
//             case "5":
//                 processInput();
//                 return "PlaceOrder";
//             default:
//                 Console.WriteLine("");
//                 Console.WriteLine("You Have Entered An Invalid Choice");
//                 Console.WriteLine("Press ENTER to try again");
//                 Console.ReadLine();
//                 return "PlaceOrderMenu";
//         }
//     }

//     public void processInput()
//     {
//         bool storeFound = false;
//         Console.WriteLine("");
//         Console.WriteLine("Please Enter Store Number");
//         _newStoreFront.StoreNumber = Convert.ToInt32(Console.ReadLine());
        
//         (_newStoreFront, storeFound) = _storeFrontBL.findStore(_newStoreFront);

//         if (storeFound)
//         {
//             Log.Information($"User succesfully added store {_newStoreFront.StoreNumber} to order");
//             addedStore = true;
//             Console.WriteLine("");
//             Console.WriteLine("Store Has Been Added To Order");
//             Console.WriteLine("Press ENTER to continue");
//             Console.ReadLine();
//         }
//         else
//         {
//             Log.Information($"User added store {_newStoreFront.StoreNumber} to order but store doesn't exist");
//             Console.WriteLine("Incorrect Store Number\nPress ENTER to go back and Try Again");
//             Console.ReadLine();
//         }
//     }

//     public void resetState()
//     {
//         readyToProcess = false;
//         addedStore = false;
//         addedCostumer = false;
//         addedItem = false;
//         costumerFound = false;

//         _listOfProducts = new List<Products>();
//         _listOfStock = new List<StoreInventory>();
//         _newCostumer = new Costumer();
//         _newStoreFront = new StoreFront();
//         _currProduct = new Products();
//         _currStock = new StoreInventory();
//     }


// }