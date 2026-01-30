using System;

public class Solution
{
    public static double ConvertFeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        Console.Write("Enter feet: ");
        int feet = int.Parse(Console.ReadLine());

        double result = ConvertFeetToCentimeters(feet);

        Console.WriteLine("Centimeters: " + result);
    }
}
