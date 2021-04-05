using System;
using Domain;
using Utilities;

namespace CustomTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(RomanNumeral.NumToRoman(10));
            Console.WriteLine(RomanNumeral.NumToRoman(123));
            Console.WriteLine(RomanNumeral.NumToRoman(2020));
            Console.WriteLine(RomanNumeral.NumToRoman(1));
            Console.WriteLine(RomanNumeral.NumToRoman(3999));

            Utils.WaitForEnter();
        }
    }
}
