using System;

namespace Renderer
{
    /* Classes in this namespace are used to render the game on screen based on the current game state.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Random dice = new Random();
            int highestVal = 0;
            int lowestVal = 6;


            for (int i = 0; i < 100; i++)
            {
                int gen = dice.Next(1, 7);
                if(gen > highestVal)
                {
                    highestVal = gen;
                }

                if(gen < lowestVal)
                {
                    lowestVal = gen;
                }


                Console.WriteLine($"Roll {i}:" + gen);
            }

            Console.WriteLine("Highest Value: " +highestVal);
            Console.WriteLine("Lowest Value: " + lowestVal);



        }
    }
}
