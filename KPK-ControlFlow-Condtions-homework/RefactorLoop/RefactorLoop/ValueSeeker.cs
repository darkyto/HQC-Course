namespace RefactorLoop
{
    using System;
    using System.Collections.Generic;

    public class ValueSeeker
    {
        public const int MaxTries = 100;
        public static void RandomComparer(int wantedValue)
        {
            bool isFound = false;
            List<int> randomValuesList = new List<int>();
            Random random = new Random();

            for (int i = 0; i < MaxTries; i++)
            {
                randomValuesList.Add(random.Next(0, 1000));
                
                if (i % 10 == 0)
                {
                    Console.WriteLine("\n");
                }
                Console.Write(randomValuesList[i] + " ");

                if (randomValuesList[i] == wantedValue)
                {
                    isFound = true;
                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine("\n");
                Console.WriteLine("!!! THE SEARCHED VALUE APPEARED - ABORT ALL !!!");
            }
        }
    }
}
