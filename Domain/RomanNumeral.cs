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
        static readonly char[] CHAR_VALUES = { 'I', 'V', 'X', 'L', 'C', 'D', 'M'};
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
                if (baseValue >= 1 && baseValue <= 4)
                {
                    result += ConcatChar(CHAR_VALUES[i], baseValue);
                }
                if (baseValue >= 4 && baseValue <= 8)
                {
                    result += CHAR_VALUES[i + 1].ToString(); 
                }
                if (baseValue >= 6 && baseValue <= 9)
                {
                    result += ConcatChar(CHAR_VALUES[i], baseValue - 5);
                }
                if (baseValue == 9)
                {
                    result += CHAR_VALUES[i + 2].ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a string representing 'value' in roman numeral
        /// </summary>
        /// <param name="value">the float to converter. The number most be between 1 and 3999. The value will be converted to an integer</param>
        /// <returns>Roman Numeral equilvalen to 'value'</returns>
        public static string NumToRoman(float value)
        {
            int convert = (int)value;

            return NumToRoman(convert);
        }

        public static int RomanToNum(string value)
        {
            int result = 0;
            value = value.ToUpper();
            char[] valueChars = value.ToCharArray();

            for (int i = 0; i < value.Length; i++)
            {

                int currentValue = CharToIntValue(valueChars[i]);

                if (i != value.Length - 1)
                {
                    if (currentValue < CharToIntValue(valueChars[i + 1]))
                    {
                        currentValue *= -1;
                    }

                }
                
                result += currentValue;
            }

            if (value != NumToRoman(result))
            {
                throw new ArgumentException(value + " not a valid Roman Number");
            }

            return result;
        }

        private static int CharToIntValue(char character)
        {
            
            for (int i = 0; i < NB_OF_VALUES; i++)
            {
                if (character == CHAR_VALUES[i])
                {
                    return INT_VALUES[i];
                }
            }

            throw new ArgumentException(character + " is not a valid roman numeral character");
        }

        /// <summary>
        /// concatenate the correct number of character for a maximum of 3 based on the value of the number provided
        /// </summary>
        /// <param name="character">the character to concatenate</param>
        /// <param name="number">the number of concatenation (loops around 3</param>
        /// <returns>string containing the character repeated a maximum of 3 times</returns>
        private static string ConcatChar(char character, int number)
        {
            return new string(character, ((number - 1) % 3) + 1);
        }
    }
}
