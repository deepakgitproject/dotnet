using System;

public class Solution
{
    public static int[] GetMultiplicationRow(int n, int upto)
    {
        int[] result = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            result[i - 1] = n * i;
        }

        return result;
    }

    public static void Main()
    {
        Console.Write("Enter number (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter upto: ");
        int upto = int.Parse(Console.ReadLine());

        int[] table = GetMultiplicationRow(n, upto);

        Console.Write("Multiplication Table Row: ");
        foreach (int value in table)
        {
            Console.Write(value + " ");
        }
    }
}

/*
▶️ Sample Execution

Input:
Enter number (n): 3
Enter upto: 5

Output:
Multiplication Table Row: 3 6 9 12 15
*/
