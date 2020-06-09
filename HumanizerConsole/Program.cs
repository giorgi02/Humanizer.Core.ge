using Humanizer.Core.ge;
using System;

namespace HumanizerConsole
{
    class Program
    {
        static void Main()
        {
            //var k = NumberToWord.AmountToWords(101.155);
            var k1 = AmountHelper.AmountToWords(101.155, "", "");

            var k2 = 10.0;

           var k = k2.ToWords();

            Console.WriteLine("Hello World!");
        }
    }
}
