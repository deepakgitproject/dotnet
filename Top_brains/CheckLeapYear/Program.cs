using System;

public class Solution
{
    // Converts feet to centimeters
    // 1 foot = 30.48 cm
    // Result is rounded to 2 decimal places using AwayFromZero
    public static double ConvertFeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }

    // Main method for execution
    public static void Main()
    {
        // Read input from user
        Console.Write("Enter feet: ");
        int feet = int.Parse(Console.ReadLine());

        // Call conversion method
        double result = ConvertFeetToCentimeters(feet);

        // Display result
        Console.WriteLine("Centimeters: " + result);
    }
}

/*
▶️ Sample Execution

Input:
Enter feet: 5

Output:
Centimeters: 152.40
*/
