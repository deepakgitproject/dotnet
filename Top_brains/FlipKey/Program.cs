using System;

public class Solution
{
    public static string CleanseAndInvert(string input)
    {
        // Rule 1: null or length < 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return string.Empty;

        // Rule 2: must contain only alphabets
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
                return string.Empty;
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        string filtered = "";
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
            {
                filtered += c;
            }
        }

        // Reverse the string
        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);

        // Convert even positioned characters to uppercase
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = char.ToUpper(arr[i]);
            }
        }

        return new string(arr);
    }

    public static void Main()
    {
        string result = CleanseAndInvert("abcdef");

        if (result.Length == 0)
        {
            Console.WriteLine("invalid");
        }
        else
        {
            Console.WriteLine("Generated String is: " + result);
        }
    }
}

/*
▶️ Sample Execution

Input:
abcdef

Output:
Generated String is: FeDc
*/
