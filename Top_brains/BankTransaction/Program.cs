using System;

public class Solution
{
    // Method to calculate final bank balance
    public static int GetFinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        // Process each transaction
        foreach (int txn in transactions)
        {
            if (txn >= 0)
            {
                // Deposit: add amount to balance
                balance += txn;
            }
            else
            {
                // Withdrawal: subtract only if sufficient balance
                if (balance + txn >= 0)
                {
                    balance += txn;
                }
            }
        }

        return balance;
    }

    // Main method for execution
    public static void Main()
    {
        // Initial account balance
        int initialBalance = 1000;

        // List of transactions
        int[] transactions = { 200, -300, -500, 400, -200 };

        // Calculate final balance
        int finalBalance = GetFinalBalance(initialBalance, transactions);

        // Display result
        Console.WriteLine("Final Balance: " + finalBalance);
    }
}

/*
▶️ Sample Execution

Input:
Initial Balance = 1000
Transactions = { 200, -300, -500, 400, -200 }

Output:
Final Balance: 600
*/
