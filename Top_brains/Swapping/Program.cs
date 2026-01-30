using System;

public class Solution
{
    // Method 1: Swap using ref
    public static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    // Method 2: Swap using out
    public static void SwapUsingOut(int a, int b, out int x, out int y)
    {
        x = b;
        y = a;
    }

    public static void Main()
    {
        int a = 10;
        int b = 20;

        Console.WriteLine("Before Swap using ref: a = " + a + ", b = " + b);
        SwapUsingRef(ref a, ref b);
        Console.WriteLine("After Swap using ref: a = " + a + ", b = " + b);

        int x, y;
        SwapUsingOut(a, b, out x, out y);
        Console.WriteLine("After Swap using out: x = " + x + ", y = " + y);
    }
}

/*
▶️ Sample Execution

Output:
Before Swap using ref: a = 10, b = 20
After Swap using ref: a = 20, b = 10
After Swap using out: x = 10, y = 20
*/
