using System;
using Domain;
using Utilities;

namespace CustomTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(RomanNumeral.NumToRoman(1));
            Console.WriteLine(RomanNumeral.NumToRoman(2));
            Console.WriteLine(RomanNumeral.NumToRoman(3));
            Console.WriteLine(RomanNumeral.NumToRoman(4));
            Console.WriteLine(RomanNumeral.NumToRoman(5));
            Console.WriteLine(RomanNumeral.NumToRoman(6));
            Console.WriteLine(RomanNumeral.NumToRoman(7));
            Console.WriteLine(RomanNumeral.NumToRoman(8));
            Console.WriteLine(RomanNumeral.NumToRoman(9));
            Console.WriteLine(RomanNumeral.NumToRoman(10));

            Utils.WaitForEnter();
        }
    }
}
