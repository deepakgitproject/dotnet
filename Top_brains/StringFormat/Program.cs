using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

// Record definition
public record Student(string Name, int Score);

public class Solution
{
    public static string BuildStudentJson(string[] items, int minScore)
    {
        List<Student> students = new List<Student>();

        foreach (string item in items)
        {
            string[] parts = item.Split(':');
            if (parts.Length == 2 && int.TryParse(parts[1], out int score))
            {
                students.Add(new Student(parts[0], score));
            }
        }

        var filteredSorted = students
            .Where(s => s.Score >= minScore)
            .OrderByDescending(s => s.Score)
            .ThenBy(s => s.Name)
            .ToList();

        return JsonSerializer.Serialize(filteredSorted);
    }

    public static void Main()
    {
        string[] items =
        {
            "Ravi:85",
            "Suraj:92",
            "Amit:85",
            "Neha:70",
            "Kiran:95"
        };

        int minScore = 85;

        string jsonResult = BuildStudentJson(items, minScore);
        Console.WriteLine(jsonResult);
    }
}

/*
▶️ Sample Execution

Input:
items = {
  "Ravi:85",
  "Suraj:92",
  "Amit:85",
  "Neha:70",
  "Kiran:95"
}
minScore = 85

Output:
[
  {"Name":"Kiran","Score":95},
  {"Name":"Suraj","Score":92},
  {"Name":"Amit","Score":85},
  {"Name":"Ravi","Score":85}
]
*/
