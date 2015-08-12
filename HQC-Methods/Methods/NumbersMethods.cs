namespace Methods
{
    using System;

    public class NumbersMethods
    {
        public static string NumberTranslator(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new FormatException("Invalid input at DigitTranslation (accepts int 0-9)");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Invalid input at FindMax(int[] input)");
            }

            int max = int.MinValue;
            int len = elements.Length;

            for (int i = 0; i < len; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void FormatNumber(double number, string format)
        {
            try
            {
                number = Convert.ToDouble(number);
            }
            catch (ArgumentException)
            {
                throw;
            }

            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid input at FormatNumber> format");
            }
        }
    }
}
