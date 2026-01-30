using System;

public class Solution
{
    // Calculate sum of digits of a number
    public static int SumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    // Check if a number is prime
    public static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    // Check if a number is Lucky
    public static bool IsLuckyNumber(int x)
    {
        // Lucky number must be non-prime and positive
        if (x <= 0 || IsPrime(x))
            return false;

        int s1 = SumOfDigits(x);
        int s2 = SumOfDigits(x * x);

        return s2 == s1 * s1;
    }

    public static void Main()
    {
        Console.Write("Enter m: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int count = 0;

        for (int i = m; i <= n; i++)
        {
            if (IsLuckyNumber(i))
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}

/*
▶️ Sample Execution

Input:
20
30

Output:
4
*/
