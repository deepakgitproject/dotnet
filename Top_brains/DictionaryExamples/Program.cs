using System;
using System.Collections.Generic;

public class Solution
{
    public static int GetTotalSalary(Dictionary<int, int> salaryDict, int[] ids)
    {
        int total = 0;

        foreach (int id in ids)
        {
            if (salaryDict.ContainsKey(id))
            {
                total += salaryDict[id];
            }
        }

        return total;
    }

    public static void Main()
    {
        // Dictionary of EmployeeId and Salary
        Dictionary<int, int> salaries = new Dictionary<int, int>
        {
            { 1, 20000 },
            { 4, 40000 },
            { 5, 15000 }
        };

        // List of Employee IDs
        int[] ids = { 1, 4, 5 };

        int totalSalary = GetTotalSalary(salaries, ids);
        Console.WriteLine("Total Salary: " + totalSalary);
    }
}

/*
▶️ Sample Execution

Input:
Ids: { 1, 4, 5 }
Dictionary: { 1:20000, 4:40000, 5:15000 }

Output:
Total Salary: 75000
*/
