using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        int len = arr.Length;
        Debug.Assert(arr != null, "Input array is null");
        Debug.Assert(len > 0, "Input array is empty");
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        int len = arr.Length;
        Debug.Assert(arr != null, "Input array is null");
        Debug.Assert(len > 1, "Input array has less then 2 elements");

        for (int index = 0; index < len - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, len - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        int len = arr.Length;
        Debug.Assert(arr != null, "Input array is null");
        Debug.Assert(len > 0, "Input array is empty");
        Debug.Assert(startIndex >= 0, "Start index should be equal or greater then zero");
        Debug.Assert(startIndex < len - 1, "Start index should be less then array lenght");
        Debug.Assert(endIndex >= 0, "End index should be equal or greater then zero");
        Debug.Assert(endIndex < len - 1, "End index should be less then array lenght");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        int len = arr.Length;
        Debug.Assert(arr != null, "Input array is null");
        Debug.Assert(len > 0, "Input array is empty");
        Debug.Assert(startIndex >= 0, "Start index should be equal or greater then zero");
        Debug.Assert(startIndex < len - 1, "Start index should be less then array lenght");
        Debug.Assert(endIndex >= 0, "End index should be equal or greater then zero");
        Debug.Assert(endIndex < len - 1, "End index should be less then array lenght");     

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                startIndex = midIndex + 1;
            }
            else 
            {
                endIndex = midIndex - 1;
            }
        }

        Debug.Assert(startIndex > endIndex, "startIndex should be greated then endIndex");
        return -1;
    }
}
