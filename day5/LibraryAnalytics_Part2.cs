using System;

namespace LibrarySystem
{
    partial class LibraryAnalytics
    {
        // Static method to display analytics
        public static void DisplayAnalytics()
        {
            Console.WriteLine("Total Items Borrowed: " + TotalBorrowedItems);
        }
    }
}
