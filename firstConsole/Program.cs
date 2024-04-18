using System;
using System.Dynamic;
namespace firstConsole;

class Program
{
    static void Main(string[] args)
    {
        // int intValue;
        // Console.WriteLine("Enter number:");
        // intValue = Convert.ToInt16(Console.ReadLine());


        // Console.WriteLine("Hello, World! " + intValue);
        // Console.WriteLine(intValue);

        // for (int i = 1; i < 101; i++)
        // {
        //    switch(true)
        //    {
        //         case true when (i % 3 == 0) && (i % 5 == 0):
        //             Console.WriteLine("fizzbuzz");
        //             break;
        //         case true when i % 3 == 0:
        //             Console.WriteLine("fizz");
        //             break;
        //         case true when i % 5 == 0:
        //             Console.WriteLine("buzz");
        //             break;
        //         default:
        //             Console.WriteLine(i);
        //             break;
        //    }

        var p1 = new Person()
        {
            Name = "Mike",
            Age = 45
        };

        var p2 = new Person()
        {
            Name = "Jake",
            Age = 24
        };

        p1 = p2;

        p2.Name = "Freddy";

        Console.WriteLine("p1 " + p1.Name);
        Console.WriteLine("p2 " + p2.Name);

        // }
    }
}
    public class Person
    {
        public string? Name {get; set;}
        public int Age {get; set;}
    }
