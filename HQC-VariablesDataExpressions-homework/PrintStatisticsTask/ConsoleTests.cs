namespace PrintStatisticsTask
{
    using System;

    public class ConsoleTests
    {
        public static void Main()
        {
            double[] numbers = { 2.25, 3.37, 4.45465, 5.65677, 3.01245, 2.56478 };
            Statistics.PrintStatistics(numbers);
        }
    }
}
