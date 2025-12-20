using System;

class Finance
{
    public static void Bank()
    {
        bool check = true;
        double total = 0;
        double tax = 0;



        while (check)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Check Loan Eligibility");
            Console.WriteLine("2. Calculate Tax");
            Console.WriteLine("3. Enter Transactions");
            Console.WriteLine("4. View Total Deposit");
            Console.WriteLine("5. Exit");

            int a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Console.Write("Enter age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    if (age < 21)
                        Console.WriteLine("Sorry, you are not eligible for loan");
                    else
                        Console.WriteLine("Congratulations, you are eligible for loan");
                    break;

                case 2:
                    Console.Write("Enter annual income: ");
                    double income = Convert.ToDouble(Console.ReadLine());
                    // double tax=0;
                    if (income <= 250000)
                        Console.WriteLine("Tax Rate: 0%");
                     else if (income <= 500000)
                        Console.WriteLine("Tax Rate: 5%");
                    else if (income <= 1000000)
                        Console.WriteLine("Tax Rate: 20%");
                    else
                        Console.WriteLine("Tax Rate: 30%");
                    
                    if (income > 250000)
                        {
                        if (income <= 500000)
                            tax = (income - 250000) * 0.05;
                        else if (income <= 1000000)
                            tax = (250000 * 0.05) + (income - 500000) * 0.20;
                        else
                            tax = (250000 * 0.05) + (500000 * 0.20) + (income - 1000000) * 0.30;
                    }
                    Console.WriteLine("Total Tax: ₹" + tax);

                    break;
                
                case 3:
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.Write($"Enter transaction {i}: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        total += amount;
                    }
                    Console.WriteLine("Total of 5 transactions = " + total);
                    if (total > 250000)
                        {
                        if (total <= 500000)
                            tax = (total - 250000) * 0.05;
                        else if (total <= 1000000)
                            tax = (250000 * 0.05) + (total - 500000) * 0.20;
                        else
                            tax = (250000 * 0.05) + (500000 * 0.20) + (total - 1000000) * 0.30;
                    }
                    Console.WriteLine("Total Tax: ₹" + tax);
                    break;
                case 4:
                    Console.WriteLine("Total amount = " + total);
                    break;
                case 5:
                    check = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
