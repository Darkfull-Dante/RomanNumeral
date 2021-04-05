using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RomanNumeral
    {

        static readonly int[] INT_VALUES = { 1, 5, 10, 50, 100, 500, 1000 };
        static readonly char[] CHAR_VALUES = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        const int NB_OF_VALUES = 7;
        const int MAX_VALUE = 3999;

        
        /// <summary>
        /// Returns a string representing 'value' in roman numeral
        /// </summary>
        /// <param name="value">the integer to converter. The number most be between 1 and 3999</param>
        /// <returns>Roman Numeral equilvalen to 'value'</returns>
        public static string NumToRoman(int value)
        {
            //check if value is higher than maximum, if so, throw exception
            if (value > MAX_VALUE)
            {
                throw new ArithmeticException("Value is higher than maximum (" + MAX_VALUE + ")");
            }
            else if (value < 1)
            {
                throw new ArithmeticException("Value is lower than minimum (1)");
            }

            string result = "";

            // loop through each base ten values;
            for (int i = NB_OF_VALUES - 1; i >= 0; i -= 2)
            {
                //check the value in the current base 10
                int baseValue = value / INT_VALUES[i];

                //remove current base 10 from the value for next iteration
                value %= INT_VALUES[i];

                //on zero skip to next loop
                if (baseValue == 0)
                {
                    continue;
                }
                else if (baseValue >= 1 && baseValue <= 4)
                {
                    result += ConcatChar(CHAR_VALUES[i], baseValue);
                }
                else if (baseValue >= 4 && baseValue <= 8)
                {
                    result += CHAR_VALUES[i + 1].ToString(); 
                }
                else if (baseValue >= 6 && baseValue <= 9)
                {
                    result += ConcatChar(CHAR_VALUES[i], baseValue);
                }
                else if (baseValue == 9)
                {
                    result += CHAR_VALUES[i + 2].ToString();
                }
            }

            return result;
        }

        private static string ConcatChar(char character, int number)
        {
            return new string(character, ((number - 1) % 3) + 1);
        }
    }
}
