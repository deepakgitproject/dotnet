using System;

public class Solution
{
    public static int GetFinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int txn in transactions)
        {
            if (txn >= 0)
            {
                // Deposit
                balance += txn;
            }
            else
            {
                // Withdraw only if enough balance
                if (balance + txn >= 0)
                {
                    balance += txn;
                }
            }
        }

        return balance;
    }
}
