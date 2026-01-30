using System;

public class Solution
{
    // Generic method to merge two sorted arrays
    public static T[] MergeSortedArrays<T>(T[] a, T[] b) where T : IComparable<T>
    {
        T[] result = new T[a.Length + b.Length];

        int i = 0, j = 0, k = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i].CompareTo(b[j]) <= 0)
            {
                result[k++] = a[i++];
            }
            else
            {
                result[k++] = b[j++];
            }
        }

        while (i < a.Length)
        {
            result[k++] = a[i++];
        }

        while (j < b.Length)
        {
            result[k++] = b[j++];
        }

        return result;
    }

    public static void Main()
    {
        int[] arr1 = { 1, 3, 5, 7 };
        int[] arr2 = { 2, 4, 6, 8 };

        int[] merged = MergeSortedArrays(arr1, arr2);

        Console.Write("Merged Array: ");
        foreach (int x in merged)
        {
            Console.Write(x + " ");
        }
    }
}

/*
▶️ Sample Execution

Input:
a = { 1, 3, 5, 7 }
b = { 2, 4, 6, 8 }

Output:
Merged Array: 1 2 3 4 5 6 7 8
*/
