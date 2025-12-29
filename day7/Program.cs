// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Runtime.CompilerServices;
// class Program
// {
//     static void Main()
    // {

// int [] src = {1,2,3};
// int [] dest = new int[3];

// int resizeed = 1;
// Array.Copy(src,dest,2);
// int [] dest2 = {1,2,123};
// bool found = Array.Exists(dest2,x=> x < 10);
// Array.Resize(ref dest2,1);
// Console.WriteLine(found);
// for(int i=0; i<resizeed; i++)
// {
//     Console.Write(dest2[i] +" ");
// }


// List<int> numbersl =new List<int>();
// numbersl.Add(1);
// numbersl.Add(2);
// numbersl.Add(3);

// ArrayList listl = new ArrayList() ;
// listl.Add(1);
// listl.Add("as");


// for(int i=0; i<listl.Count; i++)
//         {
//             Console.WriteLine(listl[i]);
//             Console.WriteLine(numbersl[i]);
//         }


// Hashtable ht = new Hashtable();
// ht.Add(1,"one");
// ht.Add(2,"two");

// Console.WriteLine(ht[1]);

// Stack stack = new Stack();
// stack.Push(1);
// stack.Push(2);
// Console.WriteLine(stack.Pop());

        // Dictionary<int, string> dict = new Dictionary<int, string>()
        // {
        //     {1, "One"},
        //     {2, "Two"},
        //     {3, "Three"}
        // };

        // foreach (var item in dict.OrderByDescending(x => x.Key))    
        // {
        //     Console.WriteLine($"{item.Key} : {item.Value}");
        // }

        // Console.WriteLine("First one");
        // int[] arr = {1,2,2,3,1,4,2};

        // Dictionary<int,int> feq = new Dictionary<int,int>();

        // for(int i=0; i<arr.Length; i++)
        // {
        //     if (feq.ContainsKey(arr[i]))
        //     {
        //         feq[arr[i]]++;
        //     }
        //     else
        //     {
        //         feq[arr[i]]=1;
        //     }
        // }
        // foreach (var item in feq)
        // {
        //     Console.WriteLine(item.Key + " -> " + item.Value);
        // }




        // Console.WriteLine("Second one");
        // Console.WriteLine();
        // int[] arr1 = {1, 3, 5};
        // int[] arr2 = {2, 4, 6};

        // int n = arr1.Length+arr2.Length;
        // int iss=0;
        // int j=0;
        // int [] arr3 = new int[n];
        // int k=0;
        // while(iss< arr1.Length && j < arr2.Length)
        // {
        //     if (arr1[iss] <= arr2[j])
        //     {
        //         arr3[k++]=arr1[iss++];
        //     }
        //     else
        //     {
        //         arr3[k++]=arr2[j++];
        //     }
        // }
        // while (iss < arr1.Length)
        //     arr3[k++] = arr1[iss++];
        // while (j < arr2.Length)
        //     arr3[k++] = arr2[j++];

        // foreach(var item in arr3)
        // {
        //     Console.WriteLine(item+" ");
        // }


    //       string s = Console.ReadLine();
    //     Sus a = new Sus();
    //     string result = a.con(s);
    //     Console.WriteLine(result);
        
    // }
    // }




using System;
using System.Collections.Generic;
using System.Linq;

// 1) Abstract Base Class
public abstract class EmployeeRecord
{
    public string EmployeeName { get; set; }
    public double[] WeeklyHours { get; set; }

    public abstract double GetMonthlyPay();
}

// Full Time Employee
public class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }
    public double MonthlyBonus { get; set; }

    public override double GetMonthlyPay()
    {
        return WeeklyHours.Sum() * HourlyRate + MonthlyBonus;
    }
}

// Contract Employee
public class ContractEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }

    public override double GetMonthlyPay()
    {
        return WeeklyHours.Sum() * HourlyRate;
    }
}

public class Program
{
    // 2) Static Collection
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

    // Register Employee
    public void RegisterEmployee(EmployeeRecord record)
    {
        PayrollBoard.Add(record);
    }

    // Overtime Week Count
    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var emp in records)
        {
            int count = emp.WeeklyHours.Count(h => h >= hoursThreshold);
            if (count > 0)
                result[emp.EmployeeName] = count;
        }

        return result;
    }

    // Average Monthly Pay
    public double CalculateAverageMonthlyPay()
    {
        if (PayrollBoard.Count == 0)
            return 0;

        double total = 0;
        foreach (var emp in PayrollBoard)
            total += emp.GetMonthlyPay();

        return total / PayrollBoard.Count;
    }

    // Main Method
    static void Main()
    {
        Program p = new Program();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nSelect Employee Type (1-Full Time, 2-Contract):");
                    int type = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Employee Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("\nEnter Hourly Rate:");
                    double rate = double.Parse(Console.ReadLine());

                    double[] hours = new double[4];
                    Console.WriteLine("\nEnter weekly hours (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                        hours[i] = double.Parse(Console.ReadLine());

                    if (type == 1)
                    {
                        Console.WriteLine("\nEnter Monthly Bonus:");
                        double bonus = double.Parse(Console.ReadLine());

                        FullTimeEmployee fte = new FullTimeEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            MonthlyBonus = bonus,
                            WeeklyHours = hours
                        };
                        p.RegisterEmployee(fte);
                    }
                    else
                    {
                        ContractEmployee ce = new ContractEmployee
                        {
                            EmployeeName = name,
                            HourlyRate = rate,
                            WeeklyHours = hours
                        };
                        p.RegisterEmployee(ce);
                    }

                    Console.WriteLine("\nEmployee registered successfully\n");
                    break;

                case 2:
                    Console.WriteLine("\nEnter hours threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    var summary = p.GetOvertimeWeekCounts(PayrollBoard, threshold);
                    if (summary.Count == 0)
                    {
                        Console.WriteLine("\nNo overtime recorded this month\n");
                    }
                    else
                    {
                        Console.WriteLine();
                        foreach (var item in summary)
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    double avg = p.CalculateAverageMonthlyPay();
                    Console.WriteLine($"\nOverall average monthly pay: {avg}\n");
                    break;

                case 4:
                    Console.WriteLine("\nLogging off — Payroll processed successfully!");
                    running = false;
                    break;
            }
        }
    }
}
