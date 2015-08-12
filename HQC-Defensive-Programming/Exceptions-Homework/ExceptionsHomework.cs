using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("null input at arr argument");
        }

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex value out of the input array range");
        }

        if (count < 0)
        {
            throw new ArgumentNullException("null/negative input at count argument");
        }

        if (count > arr.Length || (startIndex + count) > arr.Length)
        {
            throw new ArgumentOutOfRangeException("count value out of the input array range");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (!(str is string))
        {
            throw new FormatException("Invalid format input for str");
        }

        if (str == null || str == string.Empty)
        {
            throw new ArgumentNullException("Null input value for str");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("Invalid count value - larger then str lenght!");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        try
        {
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.Error.WriteLine(exception.Message);
        }

        var primeCandidate = 17;
        Console.WriteLine("Is the number " + primeCandidate + " really a prime : " 
            + (CheckPrime(primeCandidate) ? true : false));
        var fakePrime = 33;
        Console.WriteLine("Is the number " + fakePrime + " really a prime : "
            + (CheckPrime(fakePrime) ? true : false));

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        List<Exam> mariaResults = new List<Exam>()
        {
            new SimpleMathExam(9),
            new CSharpExam(80),
            new CSharpExam(75),
            new SimpleMathExam(8),
            new CSharpExam(10),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        Student maria = new Student("Maria", "Petrova", mariaResults);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        double mariaAverageResult = maria.CalcAverageExamResultInPercents();
        Console.WriteLine("(Petur Petrov) Average results = {0:p0}", peterAverageResult);
        Console.WriteLine("(Maria Petrova) Average results = {0:p0}", mariaAverageResult);
    }
}
