using System;

public class Solution
{
    public static double ConvertFeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }
}

/*
▶️ Sample Execution (Platform Driven)

Input:
feet = 5

Output:
152.40
*/
