namespace ThreeNumbersRefactorExamCSharp
{
    using System;

    public class MainConsoleApp
    {
        public static void Main()
        {
            decimal first = decimal.Parse(Console.ReadLine());
            decimal second = decimal.Parse(Console.ReadLine());
            decimal third = decimal.Parse(Console.ReadLine());

            var result = GenerateMinMaxAverage(first, second, third);

            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
            Console.WriteLine("{0:F2}",result[2]);
           
        }
        public static decimal[] GenerateMinMaxAverage(decimal a, decimal b, decimal c)
        {
            decimal[] answerArray = new decimal[3];
            answerArray[0] = Math.Max(Math.Max(a, b), c);
            answerArray[1] = Math.Min(Math.Min(a, b), c);
            decimal averageValue = (a + b + c) / 3;
            answerArray[2] = averageValue;

            return answerArray;
        }
    }
}
