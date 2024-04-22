using System.Collections;
using System.Diagnostics;

namespace StringArray;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");

        List<string> grocery_items = new List<string>();
        int intGrocery_items_count;
        bool reapeat_selection = true;
        bool repeat_shopping = true;

        while(reapeat_selection)
        {

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Add Item");
            Console.WriteLine("2 - Shop");

            int intSelection = Convert.ToInt16(Console.ReadLine());

            switch (intSelection)
            {
                case 0:
                    reapeat_selection = false;
                    break;
                case 1:
                    bool repeat_adding_items = true;
                    while(repeat_adding_items)
                    {
                        Console.WriteLine("Add Item. Enter 0 to stop.");
                        string added_items;
                        added_items = Console.ReadLine();
                        if(added_items == "0")
                        {
                            for(int i = 0; i < grocery_items.Count(); i++)
                            {
                                Console.WriteLine(i + " "  + grocery_items[i]);
                            };
                            repeat_adding_items = false;
                            break;
                            
                        }else{
                            intGrocery_items_count = grocery_items.Count;
                            grocery_items.Insert(intGrocery_items_count, added_items);
                        }
                    }
                        break;
                    
                    
                case 2:
                    bool[] in_cart = new bool[grocery_items.Count()];
                    repeat_shopping = true;

                    while(repeat_shopping)
                    {
                        Console.WriteLine("Please indicate what you have selected into your cart");
                        // Console.ReadLine();
                        in_cart[Convert.ToInt16(Console.ReadLine())] = true;


                        for(int i = 0; i < grocery_items.Count(); i++)
                        {
                            string purchased = "Purchased";
                            if(in_cart[i])
                            {
                                purchased = "Purchased";
                            }else{
                                purchased = "still needed";
                            }
                            Console.WriteLine(i + " "  + grocery_items[i] + " "+ purchased);
                        }

                        Console.WriteLine("Are you finished shopping Y/N?");
                        string userinput = Console.ReadLine();
                        if(userinput.ToLower() != "y")
                        {
                            repeat_shopping = true;
                        }else{
                            repeat_shopping = false;
                        }
                    };

                    break;
                default:
                    break;

            };
        };
        

        // var grocery_items = new ArrayList();


        // string[] grocery_items = {"apples","milk","peanut butter","eggs","jam"};
        // bool[] in_cart = new bool[grocery_items.Count()];

        // while(repeat)
        // {
        //     Console.WriteLine("Please indicate what you have selected into your cart");
        //     // Console.ReadLine();
        //     in_cart[Convert.ToInt16(Console.ReadLine())] = true;


        //     for(int i = 0; i < grocery_items.Count(); i++)
        //     {
        //         string purchased = "Purchased";
        //         if(in_cart[i])
        //         {
        //             purchased = "Purchased";
        //         }else{
        //             purchased = "still needed";
        //         }
        //         Console.WriteLine(i + " "  + grocery_items[i] + " "+ purchased);
        //     }

        //     Console.WriteLine("Are you finished Y/N?");
        //     string userinput = Console.ReadLine();
        //     if(userinput.ToLower() != "y")
        //     {
        //         repeat = true;
        //     }else{
        //         repeat = false;
        //     }
        // };
        // while(repeat);

    }
}
