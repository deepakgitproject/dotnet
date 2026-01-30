using System;

public class Solution
{
    public static string GetHeightCategory(int heightCm)
    {
        if (heightCm < 150)
        {
            return "Short";
        }
        else if (heightCm < 180)
        {
            return "Average";
        }
        else
        {
            return "Tall";
        }
    }

    public static void Main()
    {
        Console.Write("Enter height in centimeters: ");
        int heightCm = int.Parse(Console.ReadLine());

        string category = GetHeightCategory(heightCm);
        Console.WriteLine("Height Category: " + category);
    }
}
