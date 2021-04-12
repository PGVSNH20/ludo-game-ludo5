using System;

namespace Renderer
{
    public static class OneHundred
    {
        public static void CountThis()
        {
            OneHundredWithoutNumbers();
            OneHundredWithoutNumbersOrLoops();
            OneHundredWithoutNumbersOrLoopsOrStrings();

        }


        private static void OneHundredWithoutNumbers()
        {
            string s = "..........";
            for (int i = s.Length/s.Length; i <= s.Length*s.Length; i++)
            {
                Console.WriteLine(i);
            }
        }

        private static void OneHundredWithoutNumbersOrLoops()
        {
            string s = "..........";
            RecursiveCounter(s.Length*s.Length, s.Length/s.Length);
        }

        private static void RecursiveCounter(int max, int start)
        {
            Console.WriteLine(start);
            start++;
            if (start <= max) RecursiveCounter(max, start);
        }
        private static void OneHundredWithoutNumbersOrLoopsOrStrings()
        {
            int i = (int)Convert.ToDouble(true);
            i++;
            i *= i;
            i++;
            i += i;
            RecursiveCounter(i*i, i/i);
        }
    }
}
