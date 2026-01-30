using System;

public class Solution
{
    // Recursive method to compute GCD using Euclid's algorithm
    public static int GCD(int a, int b)
    {
        if (b == 0)
            return a;

        return GCD(b, a % b);
    }

    public static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int result = GCD(a, b);
        Console.WriteLine("GCD is: " + result);
    }
}

/*
▶️ Sample Execution

Input:
Enter first number: 48
Enter second number: 18

Output:
GCD is: 6
*/
