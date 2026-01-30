using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    // Helper method to check vowel
    private static bool IsVowel(char c)
    {
        c = char.ToLower(c);
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    public static string ProcessWords(string word1, string word2)
    {
        if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            return string.Empty;

        // Store consonants from second word (case-insensitive)
        HashSet<char> consonantsInWord2 = new HashSet<char>();
        foreach (char c in word2)
        {
            char lower = char.ToLower(c);
            if (!IsVowel(lower))
            {
                consonantsInWord2.Add(lower);
            }
        }

        // Task 1: Remove common consonants from first word
        StringBuilder filtered = new StringBuilder();
        foreach (char c in word1)
        {
            char lower = char.ToLower(c);

            if (!IsVowel(lower) && consonantsInWord2.Contains(lower))
                continue;

            filtered.Append(c);
        }

        // Task 2: Remove consecutive duplicate characters
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < filtered.Length; i++)
        {
            if (i == 0 || filtered[i] != filtered[i - 1])
            {
                result.Append(filtered[i]);
            }
        }

        return result.ToString();
    }

    public static void Main()
    {
        Console.Write("Enter first word: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter second word: ");
        string word2 = Console.ReadLine();

        string output = ProcessWords(word1, word2);
        Console.WriteLine("Final Output: " + output);
    }
}

/*
▶️ Sample Execution

Input:
Enter first word: Balloon
Enter second word: Loan

Output:
Final Output: Bao
*/
