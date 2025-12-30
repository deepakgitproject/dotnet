// FileStream file = null;
// try
// {
//     file = new FileStream("data.txt", FileMode.Open);
//     // Perform file operations
//     int data = file.ReadByte();
//     Console.WriteLine("Read byte: " + data);
// }
// catch (FileNotFoundException ex)
// {
//     Console.WriteLine("File not found: " + ex.Message);
// }
// finally
// {
//     if (file != null)
//     {
//         file.Close(); // Ensures file is always closed
//         Console.WriteLine("File stream closed in finally block.");
//     }
// }
// using System;
// using System.Data.SqlClient;

// class Program
// {
//     static void Main(string[] args)
//     {
//         try
//         {
//             // Real DB call here
//         }
//         catch (SqlException ex)
//         {
//             throw new Exception("Database operation failed in Service Layer", ex);
//         }
//     }
// }

// using System;
// using System.IO;

// try
// {
//     try
//     {
//         string red = File.ReadAllText("transactions.txt");
//         Console.WriteLine(red);
//     }
//     catch (IOException ioEx)
//     {
//         throw new ApplicationException(
//             "Unable to load transaction data",
//             ioEx
//         );
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine("Message: " + ex.Message);
//     Console.WriteLine("Root Cause: " + ex.InnerException.Message);
// }

using System;
using System.IO;

namespace BankingSystem
{
    // ---------- CUSTOM EXCEPTIONS ----------

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message)
            : base(message)
        {
        }
    }

    public class BankOperationException : Exception
    {
        public BankOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    // ---------- BANK ACCOUNT CLASS ----------

    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException(
                    "Account number cannot be null or empty",
                    nameof(accountNumber));

            if (initialBalance < 0)
                throw new ArgumentException(
                    "Initial balance cannot be negative",
                    nameof(initialBalance));

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            try
            {
                // Input validation
                if (amount <= 0)
                    throw new ArgumentException(
                        "Withdrawal amount must be greater than zero",
                        nameof(amount));

                // Business rule
                if (amount > Balance)
                    throw new InsufficientBalanceException(
                        $"Insufficient balance. Available balance: {Balance:C}");

                Balance -= amount;

                Console.WriteLine(
                    $"Withdrawal successful. Updated balance: {Balance:C}");
            }
            catch (InsufficientBalanceException ex)
            {
                LogException(ex);
                throw; // rethrow SAME exception
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new BankOperationException(
                    "Unexpected error occurred during withdrawal operation",
                    ex);
            }
        }

        // ---------- PRIVATE LOGGING METHOD ----------

        private void LogException(Exception ex)
        {
            File.AppendAllText(
                "bank_errors.log",
                $"{DateTime.Now} | Account: {AccountNumber} | {ex}{Environment.NewLine}");
        }
    }

    // ---------- PROGRAM ENTRY POINT ----------

    class Program
    {
        static void Main()
        {
            try
            {
                // Create account
                BankAccount account =
                    new BankAccount("ACC12345", 5000);

                // Attempt overdraft
                account.Withdraw(8000);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Withdrawal Failed: " + ex.Message);
            }
            catch (BankOperationException ex)
            {
                Console.WriteLine("Bank Operation Error: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine(
                        "Root Cause: " + ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Unexpected Application Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine(
                    "Transaction process completed.");
            }
        }
    }
}
