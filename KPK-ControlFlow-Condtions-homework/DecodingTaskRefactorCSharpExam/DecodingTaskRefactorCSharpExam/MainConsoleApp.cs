namespace DecodingTaskRefactorCSharpExam
{
    using System;
    using System.Linq;

    public class MainConsoleApp : DecoderApp
    {
        public static void Main()
        {
            int salt = int.Parse(Console.ReadLine());
            string inputText = Console.ReadLine();

            Decoder(salt, inputText);
        }     
    }
}

