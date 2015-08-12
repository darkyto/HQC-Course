namespace PrintStatisticsTask
{
    using System;

    public class Statistics
    {
        public static void PrintStatistics(double[] numbersArr)
        {
            double min, max, average;
            max = ReturnMax(numbersArr);
            min = ReturnMin(numbersArr);
            average = ReturnAverage(numbersArr);
            Console.WriteLine("Max value: {0:F4}\nMin value: {1:F4}\nAverage: {2:F4}", max, min, average);
        }        
        
        /// <summary>
        /// Method to store max,min and average valiues in array
        /// </summary>
        /// <param name="numbersArr"></param>
        /// <returns>Array with Max,Min and Average values</returns>
        public static double[] ReturnStatistics(double[] numbersArr)
        {
            double min, max, average;
            double[] result = new double[3];
            max = ReturnMax(numbersArr);
            min = ReturnMin(numbersArr);
            average = ReturnAverage(numbersArr);
            result[0] = max;
            result[1] = min;
            result[2] = average;

            return result;
        }

        private static double ReturnMax(double[] numbersArr)
        {
            double maxValue = numbersArr[0];
            int len = numbersArr.Length;

            for (int i = 0; i < len; i++)
            {
                if (numbersArr[i] > maxValue)
                {
                    maxValue = numbersArr[i];
                }
            }

            return maxValue;
        }

        private static double ReturnMin(double[] numbersArr)
        {
            double minValue = numbersArr[0];
            int len = numbersArr.Length;

            for (int i = 0; i < len; i++)
            {
                if (numbersArr[i] < minValue)
                {
                    minValue = numbersArr[i];
                }
            }

            return minValue;
        }

        private static double ReturnAverage(double[] numbersArr)
        {
            double averageValue = 0;
            int len = numbersArr.Length;

            for (int i = 0; i < len; i++)
            {
                averageValue += numbersArr[i];
            }

            averageValue = averageValue / len;
            return averageValue;
        }
    }
}
