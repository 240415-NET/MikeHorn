namespace MethodException;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        bool blnCorrect = true;
        int intMenu = 0;

        do
        {
            try
            {
                Console.WriteLine("Let's talk football!");
                Console.WriteLine("Select");
                Console.WriteLine("0 - to exit");
                Console.WriteLine("1 - talk about the Bears");
                Console.WriteLine("2 - talk about the Lions");
                Console.WriteLine("3 - talk about the Colts");
                Console.WriteLine("4 - talk about the Packers");
                intMenu = Convert.ToInt16(Console.ReadLine());
                blnCorrect = false;

                switch (intMenu)
                {
                    case 0:
                        blnCorrect = true;
                        break;
                    case 1:
                        Console.WriteLine("Bears are great");
                        break;
                    case 2:
                        Console.WriteLine("Lions suck");
                        break;
                    case 3:
                        Console.WriteLine("Colts are ok");
                        break;
                    case 4:
                        Console.WriteLine("Packers suck more than the Lions");
                        break;
                    default:
                        Console.WriteLine("Packers still suck more than the Lions");
                        break;
                }

            }catch(Exception excp)
            {
                Console.WriteLine("Must be an Integer: " + excp.Message);
                blnCorrect = false;

            }
        }while(blnCorrect == false);

    }
}
