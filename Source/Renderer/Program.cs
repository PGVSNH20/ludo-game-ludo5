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


            for (int i = 0; i < 100; i++)
            {
                int gen = dice.Next(5) + 1;

                Console.WriteLine("Roll:" + gen);
            }

            
            


        }
    }
}
