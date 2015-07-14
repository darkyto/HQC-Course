namespace DecodingTaskRefactorCSharpExam
{
    using System;
    using System.Linq;

    public class DecoderApp
    {
        public const char EndCharacter = '@';

        public static void Decoder(int key, string inputText)
        {
            double charResult = 0;

            for (int i = 0; i < inputText.Length; i++)
            {
                int currentPosition = inputText[i];

                if (char.IsDigit(inputText[i]))
                {
                    charResult = key + currentPosition + 500;

                    if (i % 2 == 0)
                    {
                        charResult /= 100;
                        Console.WriteLine("{0:F2}", charResult);
                    }
                    else if (i % 2 != 0)
                    {
                        charResult *= 100;
                        Console.WriteLine("{0}", charResult);
                    }
                }
                else if (char.IsLetter(inputText[i]))
                {
                    charResult = (key * currentPosition) + 1000;

                    if (i % 2 == 0)
                    {
                        charResult /= 100;
                        Console.WriteLine("{0:F2}", charResult);
                    }
                    else if (i % 2 != 0)
                    {
                        charResult *= 100;
                        Console.WriteLine("{0}", charResult);
                    }
                }
                else if (!char.IsLetter(inputText[i]) && !char.IsDigit(inputText[i]) && inputText[i] != '@')
                {
                    charResult = currentPosition - key;

                    if (i % 2 == 0)
                    {
                        charResult /= 100;
                        Console.WriteLine("{0:F2}", charResult);
                    }
                    else if (i % 2 != 0)
                    {
                        charResult *= 100;
                        Console.WriteLine("{0}", charResult);
                    }
                }
                if (inputText[i] == EndCharacter)
                {
                    break;
                }
            }
        }
    }
}
