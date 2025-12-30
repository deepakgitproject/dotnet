// using System;
// using System.IO;
// // using System;

// namespace BankingSystem
// {
//     public class InsufficientBalanceException : Exception
//     {
//         public InsufficientBalanceException(string message)
//             : base(message)
//         {
//         }
//     }

//     public class BankOperationException : Exception
//     {
//         public BankOperationException(string message, Exception innerException)
//             : base(message, innerException)
//         {
//         }
//     }
// }

// namespace BankingSystem
// {
//     public class BankAccount
//     {
//         public string AccountNumber { get; private set; }
//         public decimal Balance { get; private set; }

//         public BankAccount(string accountNumber, decimal initialBalance)
//         {
//             if (string.IsNullOrWhiteSpace(accountNumber))
//                 throw new ArgumentException("Account number cannot be null or empty", nameof(accountNumber));

//             if (initialBalance < 0)
//                 throw new ArgumentException("Initial balance cannot be negative", nameof(initialBalance));

//             AccountNumber = accountNumber;
//             Balance = initialBalance;
//         }

//         public void Withdraw(decimal amount)
//         {
//             try
//             {
//                 if (amount <= 0)
//                     throw new ArgumentException("Withdrawal amount must be greater than zero", nameof(amount));

//                 if (amount > Balance)
//                     throw new InsufficientBalanceException(
//                         $"Insufficient balance. Available balance: {Balance:C}");

//                 Balance -= amount;

//                 Console.WriteLine($"Withdrawal successful. Updated balance: {Balance:C}");
//             }
//             catch (InsufficientBalanceException ex)
//             {
//                 LogException(ex);
//                 throw; 
//             }
//             catch (Exception ex)
//             {
//                 LogException(ex);
//                 throw new BankOperationException(
//                     "Unexpected error occurred during withdrawal operation",
//                     ex);
//             }
//         }

//         private void LogException(Exception ex)
//         {
//             File.AppendAllText(
//                 "bank_errors.log",
//                 $"{DateTime.Now} | Account: {AccountNumber} | {ex}\n");
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             // Create account
//             BankAccount account = new BankAccount("ACC12345", 5000);

//             // Attempt overdraft
//             account.Withdraw(8000);
//         }
//         catch (InsufficientBalanceException ex)
//         {
//             Console.WriteLine("Withdrawal Failed: " + ex.Message);
//         }
//         catch (BankOperationException ex)
//         {
//             Console.WriteLine("Bank Operation Error: " + ex.Message);

//             if (ex.InnerException != null)
//             {
//                 Console.WriteLine("Root Cause: " + ex.InnerException.Message);
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Unexpected Application Error: " + ex.Message);
//         }
//         finally
//         {
//             Console.WriteLine("Transaction process completed.");
//         }
//     }
// }
