using System;

public class Solution
{
    public static int GetLargest(int a, int b, int c)
    {
        if (a >= b && a >= c)
        {
            return a;
        }
        else if (b >= a && b >= c)
        {
            return b;
        }
        else
        {
            return c;
        }
    }

    public static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        int c = int.Parse(Console.ReadLine());

        int largest = GetLargest(a, b, c);
        Console.WriteLine("Largest number is: " + largest);
    }
}

/*
▶️ Sample Execution

Input:
Enter first number: 10
Enter second number: 25
Enter third number: 15

Output:
Largest number is: 25
*/
