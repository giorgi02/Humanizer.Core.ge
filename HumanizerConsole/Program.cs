using Humanizer.Core.ge;
using System;

namespace HumanizerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var k = NumberToWord.AmountToWords(101.155);
            var k1 = AmountHelper.AmountToWords(101.155, "", "");

            var k2 = 11012.0000000109;

           var k = k2.ToWords();

            Console.WriteLine("Hello World!");
        }
    }
}
