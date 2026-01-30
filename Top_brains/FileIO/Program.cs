using System;
using System.IO;
using System.Collections.Generic;

public class Solution
{
    public static void ExtractErrorLogs(string inputFile, string outputFile)
    {
        List<string> errorLogs = new List<string>();

        // Read all lines from input file
        string[] lines = File.ReadAllLines(inputFile);

        foreach (string line in lines)
        {
            if (line.Contains("ERROR"))
            {
                errorLogs.Add(line);
            }
        }

        // Write ERROR logs to output file
        File.WriteAllLines(outputFile, errorLogs);
    }

    public static void Main()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        ExtractErrorLogs(inputFile, outputFile);

        Console.WriteLine("ERROR logs extracted successfully.");
    }
}

/*
▶️ Sample Execution

Input File (log.txt):
INFO Application started
ERROR Database connection failed
WARN Low memory
ERROR Null reference exception

Output File (error.txt):
ERROR Database connection failed
ERROR Null reference exception
*/
