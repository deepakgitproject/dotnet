using System;
using System.Globalization;
using System.Text;

public class Solution
{
    public static string CleanInventoryName(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Step 1: Trim extra spaces
        input = input.Trim();

        // Step 2: Remove duplicate consecutive characters
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0 || input[i] != input[i - 1])
            {
                sb.Append(input[i]);
            }
        }

        // Step 3: Normalize spaces
        string cleaned = sb.ToString();
        cleaned = string.Join(" ", cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        // Step 4: Convert to Title Case
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(cleaned.ToLower());
    }

    public static void Main()
    {
        Console.Write("Enter product name: ");
        string input = Console.ReadLine();

        string result = CleanInventoryName(input);
        Console.WriteLine("Cleaned Name: " + result);
    }
}

/*
▶️ Sample Execution

Input:
" llapppptop bag "

Output:
Laptop Bag
*/
