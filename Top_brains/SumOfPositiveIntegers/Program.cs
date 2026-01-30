using System;

public class Solution
{
    public static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        foreach (int num in nums)
        {
            if (num == 0)
            {
                break; // stop processing
            }

            if (num < 0)
            {
                continue; // ignore negative numbers
            }

            sum += num; // add positive number
        }

        return sum;
    }

    public static void Main()
    {
        int[] nums = { 5, -3, 10, 2, -1, 0, 100 };

        int result = SumPositiveUntilZero(nums);
        Console.WriteLine("Sum of positive integers: " + result);
    }
}

/*
▶️ Sample Execution

Input:
nums = { 5, -3, 10, 2, -1, 0, 100 }

Output:
Sum of positive integers: 17
*/
