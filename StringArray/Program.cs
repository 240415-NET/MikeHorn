namespace StringArray;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        string[] grocery_items = {"apples","milk","peanut butter","eggs","jam"};
        bool[] in_cart = new bool[grocery_items.Count()];
        bool repeat = false;

        for(int i = 0; i < grocery_items.Count(); i++)
        {
            Console.WriteLine(i + " "  + grocery_items[i]);
        }

        
        

        do
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

            Console.WriteLine("Are you finished Y/N?");
            string userinput = Console.ReadLine();
            if(userinput.ToLower() != "y")
            {
                repeat = true;
            }else{
                repeat = false;
            }
        }
        while(repeat);

    }
}
