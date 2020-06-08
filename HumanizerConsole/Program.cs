using Humanizer.Core.ge;
using System;

namespace HumanizerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = NumberToWord.AmountToWords(101.155);
            var k1 = AmountHelper.AmountToWords(101.155, "", "");

            Console.WriteLine("Hello World!");
        }
    }
}
