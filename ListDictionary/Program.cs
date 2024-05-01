// using System;
namespace Test1;

    //DO NOT TOUCH THE CODE BELOW



class Test()
{

static void Main()
    {
            int b = int.Parse(Console.ReadLine());

            int s = int.Parse(Console.ReadLine());

            int t = int.Parse(Console.ReadLine());

            Console.WriteLine(rockGame(b,s,t));

    }



    public static int rockGame(int b, int s, int t)
    {

            //WRITE YOUR CODE HERE

            int LeftOver = b;

            int Steve = 0;

            int Tom = 0;

            string LastBoy = "";



            while(LeftOver > 0)

            {

                for(int i=1; i<3;i++)

                {



                    switch(true)

                    {

                        case true when LeftOver == 0:
                            break;
                        case true when (i==1) && ((LeftOver - s) < 0):

                            Steve += LeftOver;

                            LeftOver = 0;

                            LastBoy = "Steve";

                            i=2;

                            break;

                        case true when ((i == 1) && (LeftOver - s >= 0)):

                            Steve += s;

                            LeftOver -= s;

                            break;

                        case true when (i==2) && ((LeftOver - t) < 0):
                            Tom += LeftOver;

                            LeftOver = 0;

                            LastBoy = "Tommy";

                            break;

                        case true when (i==2) && (LeftOver - t >= 0):

                            Tom +=  t;

                            LeftOver -= t;

                            break;

                    }



                

                }

                



            }

            

            if(LastBoy == "Tommy")

            {

                return Tom;

            }

            else

            {

                return Steve;

            }

            

            

        }

}