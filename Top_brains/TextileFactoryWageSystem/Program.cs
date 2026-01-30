using System;
using System.Collections.Generic;

namespace PieceWorkWageSystem
{
    // Employee record structure
    public class EmployeeRecord
    {
        public int EmployeeId { get; set; }
        public int Product1Units { get; set; }
        public int Product2Units { get; set; }
        public int Product3Units { get; set; }
        public decimal GrossWages { get; set; }

        public override string ToString()
        {
            return $"Employee #{EmployeeId}: " +
                   $"[P1: {Product1Units}, P2: {Product2Units}, P3: {Product3Units}] " +
                   $"Wages: Rs. {GrossWages:F2}";
        }
    }

    public static class WageCalculator
    {
        // Piece rates for the three products
        private static readonly decimal[] PieceRates = { 1.20m, 1.80m, 2.25m };

        /// <summary>
        /// Calculates gross wages for an employee
        /// </summary>
        public static decimal CalculateWages(int[] units)
        {
            decimal wages = 0;
            for (int i = 0; i < units.Length; i++)
            {
                wages += units[i] * PieceRates[i];
            }
            return wages;
        }

        /// <summary>
        /// Calculates wages for a batch of employees
        /// </summary>
        public static List<EmployeeRecord> CalculateBatchWages(List<EmployeeRecord> employees)
        {
            var results = new List<EmployeeRecord>();

            foreach (var emp in employees)
            {
                int[] units =
                {
                    emp.Product1Units,
                    emp.Product2Units,
                    emp.Product3Units
                };

                emp.GrossWages = CalculateWages(units);
                results.Add(emp);
            }

            return results;
        }

        /// <summary>
        /// Generates sample employee data for testing
        /// </summary>
        public static List<EmployeeRecord> GenerateSampleData()
        {
            return new List<EmployeeRecord>
            {
                new EmployeeRecord { EmployeeId = 101, Product1Units = 100, Product2Units = 50, Product3Units = 30 },
                new EmployeeRecord { EmployeeId = 102, Product1Units = 250, Product2Units = 25, Product3Units = 10 },
                new EmployeeRecord { EmployeeId = 103, Product1Units = 0,   Product2Units = 15, Product3Units = 75 },
                new EmployeeRecord { EmployeeId = 104, Product1Units = 80,  Product2Units = 80, Product3Units = 80 },
                new EmployeeRecord { EmployeeId = 105, Product1Units = 0,   Product2Units = 0,  Product3Units = 0 },
                new EmployeeRecord { EmployeeId = 106, Product1Units = 300, Product2Units = 150,Product3Units = 100 },
                new EmployeeRecord { EmployeeId = 107, Product1Units = 0,   Product2Units = 120,Product3Units = 0 },
                new EmployeeRecord { EmployeeId = 108, Product1Units = 40,  Product2Units = 20, Product3Units = 10 },
                new EmployeeRecord { EmployeeId = 109, Product1Units = 150, Product2Units = 0,  Product3Units = 50 },
                new EmployeeRecord { EmployeeId = 110, Product1Units = 90,  Product2Units = 110,Product3Units = 65 }
            };
        }

        /// <summary>
        /// Runs batch processing with sample data
        /// </summary>
        public static void RunBatchProcessing()
        {
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("BATCH PROCESSING - FACTORY DAILY WAGE REPORT");
            Console.WriteLine(new string('=', 70));

            var employees = GenerateSampleData();
            var results = CalculateBatchWages(employees);

            Console.WriteLine("\nEmployee ID | Cotton | Silk | Woolen | Gross Wages");
            Console.WriteLine(new string('-', 65));

            decimal totalFactoryWages = 0;

            foreach (var emp in results)
            {
                Console.WriteLine($"{emp.EmployeeId,10} | {emp.Product1Units,6} | {emp.Product2Units,4} | " +
                                  $"{emp.Product3Units,6} | Rs. {emp.GrossWages,8:F2}");
                totalFactoryWages += emp.GrossWages;
            }

            Console.WriteLine(new string('-', 65));
            Console.WriteLine($"TOTAL FACTORY WAGES PAYABLE: Rs. {totalFactoryWages:F2}");

            decimal averageWage = totalFactoryWages / results.Count;
            Console.WriteLine($"AVERAGE EMPLOYEE WAGE: Rs. {averageWage:F2}");

            EmployeeRecord topPerformer = results[0];
            foreach (var emp in results)
            {
                if (emp.GrossWages > topPerformer.GrossWages)
                    topPerformer = emp;
            }

            Console.WriteLine($"TOP PERFORMER: Employee #{topPerformer.EmployeeId} with Rs. {topPerformer.GrossWages:F2}");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEXTILE FACTORY WAGE MANAGEMENT SYSTEM");
            WageCalculator.RunBatchProcessing();
        }
    }
}

/*
▶️ Sample Execution (Partial)

Employee ID | Cotton | Silk | Woolen | Gross Wages
       101 |    100 |   50 |     30 | Rs.   277.50
       106 |    300 |  150 |    100 | Rs.   855.00

TOTAL FACTORY WAGES PAYABLE: Rs. 3183.00
AVERAGE EMPLOYEE WAGE: Rs. 318.30
TOP PERFORMER: Employee #106 with Rs. 855.00
*/
