// using System;

// namespace QuickMartTraders
// {
//     // ENTITY CLASS
//     class SaleTransaction
//     {
//         public string InvoiceNo { get; set; }
//         public string CustomerName { get; set; }
//         public string ItemName { get; set; }
//         public int Quantity { get; set; }
//         public decimal PurchaseAmount { get; set; }
//         public decimal SellingAmount { get; set; }
//         public string ProfitOrLossStatus { get; set; }
//         public decimal ProfitOrLossAmount { get; set; }
//         public decimal ProfitMarginPercent { get; set; }
//     }

//     class TransactionManager
//     {
//         public static SaleTransaction LastTransaction;
//         public static bool HasLastTransaction = false;

//         // CREATE METHOD
//         public static void CreateTransaction()
//         {
//             SaleTransaction tx = new SaleTransaction();

//             Console.Write("Enter Invoice No: ");
//             tx.InvoiceNo = Console.ReadLine();
//             if (string.IsNullOrWhiteSpace(tx.InvoiceNo))
//             {
//                 Console.WriteLine("Invoice No cannot be empty.");
//                 return;
//             }

//             Console.Write("Enter Customer Name: ");
//             tx.CustomerName = Console.ReadLine();

//             Console.Write("Enter Item Name: ");
//             tx.ItemName = Console.ReadLine();

//             Console.Write("Enter Quantity: ");
//             if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
//             {
//                 Console.WriteLine("Quantity must be greater than 0.");
//                 return;
//             }
//             tx.Quantity = qty;

//             Console.Write("Enter Purchase Amount (total): ");
//             if (!decimal.TryParse(Console.ReadLine(), out decimal purchase) || purchase <= 0)
//             {
//                 Console.WriteLine("Purchase Amount must be greater than 0.");
//                 return;
//             }
//             tx.PurchaseAmount = purchase;

//             Console.Write("Enter Selling Amount (total): ");
//             if (!decimal.TryParse(Console.ReadLine(), out decimal selling) || selling < 0)
//             {
//                 Console.WriteLine("Selling Amount cannot be negative.");
//                 return;
//             }
//             tx.SellingAmount = selling;

//             Calculate(tx);

//             LastTransaction = tx;
//             HasLastTransaction = true;

//             Console.WriteLine("\nTransaction saved successfully.");
//             PrintCalculation(tx);
//         }

//         // VIEW METHOD
//         public static void ViewTransaction()
//         {
//             if (!HasLastTransaction)
//             {
//                 Console.WriteLine("No transaction available. Please create a new transaction first.");
//                 return;
//             }

//             SaleTransaction tx = LastTransaction;

//             Console.WriteLine("\n-------------- Last Transaction --------------");
//             Console.WriteLine($"InvoiceNo: {tx.InvoiceNo}");
//             Console.WriteLine($"Customer: {tx.CustomerName}");
//             Console.WriteLine($"Item: {tx.ItemName}");
//             Console.WriteLine($"Quantity: {tx.Quantity}");
//             Console.WriteLine($"Purchase Amount: {tx.PurchaseAmount:F2}");
//             Console.WriteLine($"Selling Amount: {tx.SellingAmount:F2}");
//             Console.WriteLine($"Status: {tx.ProfitOrLossStatus}");
//             Console.WriteLine($"Profit/Loss Amount: {tx.ProfitOrLossAmount:F2}");
//             Console.WriteLine($"Profit Margin (%): {tx.ProfitMarginPercent:F2}");
//             Console.WriteLine("--------------------------------------------");
//         }

//         public static void Recalculate()
//         {
//             if (!HasLastTransaction)
//             {
//                 Console.WriteLine("No transaction available. Please create a new transaction first.");
//                 return;
//             }

//             Calculate(LastTransaction);
//             PrintCalculation(LastTransaction);
//         }

//         private static void Calculate(SaleTransaction tx)
//         {
//             if (tx.SellingAmount > tx.PurchaseAmount)
//             {
//                 tx.ProfitOrLossStatus = "PROFIT";
//                 tx.ProfitOrLossAmount = tx.SellingAmount - tx.PurchaseAmount;
//             }
//             else if (tx.SellingAmount < tx.PurchaseAmount)
//             {
//                 tx.ProfitOrLossStatus = "LOSS";
//                 tx.ProfitOrLossAmount = tx.PurchaseAmount - tx.SellingAmount;
//             }
//             else
//             {
//                 tx.ProfitOrLossStatus = "BREAK-EVEN";
//                 tx.ProfitOrLossAmount = 0;
//             }

//             tx.ProfitMarginPercent = (tx.ProfitOrLossAmount / tx.PurchaseAmount) * 100;
//         }

//         private static void PrintCalculation(SaleTransaction tx)
//         {
//             Console.WriteLine($"Status: {tx.ProfitOrLossStatus}");
//             Console.WriteLine($"Profit/Loss Amount: {tx.ProfitOrLossAmount:F2}");
//             Console.WriteLine($"Profit Margin (%): {tx.ProfitMarginPercent:F2}");
//             Console.WriteLine("------------------------------------------------------");
//         }
//     }
// }