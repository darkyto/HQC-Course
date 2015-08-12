namespace Methods
{
    using System;

    public class ConsoleTests : CartesianSpaceMethods
    {
        public static void Main()
        {
            Console.WriteLine("Triangle area: " + TriangleMethods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine("Number to word translator: " + NumbersMethods.NumberTranslator(5));

            Console.WriteLine(NumbersMethods.FindMax(5, -1, 3, 2, 14, 2, 3));

            NumbersMethods.FormatNumber(1.3, "f");
            NumbersMethods.FormatNumber(0.75, "%");
            NumbersMethods.FormatNumber(2.30, "r");

            Console.WriteLine("Distance: " + CartesianSpaceMethods.CalculateDistance(3, 3, -1, 2.5));
            Console.WriteLine("Horizontal? " + CartesianSpaceMethods.HorizontalLineCheck(3, 3));
            Console.WriteLine("Vertical? " + CartesianSpaceMethods.VerticalLineCheck(-1, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.AdditionalInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.AdditionalInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                              "{0} older than {1} -> {2}",
                              peter.FirstName, 
                              stella.FirstName, 
                              Student.IsOlderThan(peter, stella));
        }
    }
}
