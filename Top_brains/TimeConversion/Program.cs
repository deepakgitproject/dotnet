using System;

public class Solution
{
    public static string ConvertSecondsToTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        return minutes + ":" + seconds.ToString("D2");
    }

    public static void Main()
    {
        Console.Write("Enter total seconds: ");
        int totalSeconds = int.Parse(Console.ReadLine());

        string result = ConvertSecondsToTime(totalSeconds);
        Console.WriteLine("Formatted Time: " + result);
    }
}

/*
▶️ Sample Execution

Input:
Enter total seconds: 125

Output:
Formatted Time: 2:05
*/
