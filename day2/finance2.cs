using System;

class Programss
{
    public static void finance2()
    {
        int mainChoice = 0;

        while (mainChoice != 3)
        {
            Console.WriteLine("--- Finance Management System ---");
            Console.WriteLine("1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            mainChoice = Convert.ToInt32(Console.ReadLine());

            switch (mainChoice)
            {
                //DEBIT
                case 1:
                    Console.WriteLine("--- Debit Operations ---");
                    Console.WriteLine("1. ATM Withdrawal Limit");
                    Console.WriteLine("2. EMI Burden Check");
                    Console.WriteLine("3. Daily Spending Calculator");
                    Console.WriteLine("4. Minimum Balance Check");
                    Console.Write("Enter choice: ");
                    int debitChoice = Convert.ToInt32(Console.ReadLine());

                    switch (debitChoice)
                    {
                        case 1:
                            Console.Write("Enter withdrawal amount: ");
                            double withdraw = Convert.ToDouble(Console.ReadLine());
                            if (withdraw <= 40000)
                                Console.WriteLine("Withdrawal permitted within daily limit.");
                            else
                                Console.WriteLine("Daily ATM withdrawal limit exceeded.");
                            break;

                        case 2:
                            Console.Write("Enter monthly income: ");
                            double income = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter EMI amount: ");
                            double emi = Convert.ToDouble(Console.ReadLine());

                            if (emi <= income * 0.40)
                                Console.WriteLine("EMI is financially manageable.");
                            else
                                Console.WriteLine("EMI exceeds safe income limit.");
                            break;

                        case 3:
                            Console.Write("Enter number of transactions: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            double totalDebit = 0;

                            for (int i = 1; i <= n; i++)
                            {
                                Console.Write("Enter amount for transaction " + i + ": ");
                                totalDebit += Convert.ToDouble(Console.ReadLine());
                            }

                            Console.WriteLine("Total debit amount for the day: ₹" + totalDebit);
                            break;

                        case 4:
                            Console.Write("Enter current balance: ");
                            double balance = Convert.ToDouble(Console.ReadLine());

                            if (balance < 2000)
                                Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
                            else
                                Console.WriteLine("Minimum balance requirement satisfied.");
                            break;

                        default:
                            Console.WriteLine("Invalid Debit Option.");
                            break;
                    }
                    break;

                // CREDIT 
                case 2:
                    Console.WriteLine("--- Credit Operations ---");
                    Console.WriteLine("1. Net Salary Calculation");
                    Console.WriteLine("2. Fixed Deposit Maturity");
                    Console.WriteLine("3. Credit Card Reward Points");
                    Console.WriteLine("4. Bonus Eligibility Check");
                    Console.Write("Enter choice: ");
                    int creditChoice = Convert.ToInt32(Console.ReadLine());

                    switch (creditChoice)
                    {
                        case 1:
                            Console.Write("Enter gross salary: ");
                            double gross = Convert.ToDouble(Console.ReadLine());
                            double net = gross - (gross * 0.10);
                            Console.WriteLine("Net salary credited: ₹" + net);
                            break;

                        case 2:
                            Console.Write("Enter principal: ");
                            double p = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter rate: ");
                            double r = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter time (years): ");
                            double t = Convert.ToDouble(Console.ReadLine());

                            double si = (p * r * t) / 100;
                            Console.WriteLine("Fixed Deposit maturity amount: ₹" + (p + si));
                            break;

                        case 3:
                            Console.Write("Enter total credit card spending: ");
                            double spend = Convert.ToDouble(Console.ReadLine());
                            int points = (int)(spend / 100);
                            Console.WriteLine("Reward points earned: " + points);
                            break;

                        case 4:
                            Console.Write("Enter annual salary: ");
                            double salary = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter years of service: ");
                            int years = Convert.ToInt32(Console.ReadLine());

                            if (salary >= 500000 && years >= 3)
                                Console.WriteLine("Employee is eligible for bonus.");
                            else
                                Console.WriteLine("Employee is not eligible for bonus.");
                            break;

                        default:
                            Console.WriteLine("Invalid Credit Option.");
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
