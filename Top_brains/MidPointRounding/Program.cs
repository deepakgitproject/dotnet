using System;

public class Solution
{
    public static double CalculateCircleArea(double radius)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        Console.Write("Enter radius: ");
        double radius = double.Parse(Console.ReadLine());

        double result = CalculateCircleArea(radius);
        Console.WriteLine("Area of circle: " + result);
    }
}

/*
▶️ Sample Execution

Input:
Enter radius: 5

Output:
Area of circle: 78.54
*/
