using System;
using System.Collections.Generic;
using lib = LibrarySystem.Items;   //  FIXED ALIAS
using LibrarySystem;
class Program
{
    static void Main()
    {
        lib.Book book = new lib.Book
        {
            Title = "C# Fundamentals",
            Author = "John Doe",
            ItemID = 101
        };

        lib.Magazine magazine = new lib.Magazine
        {
            Title = "Tech Today",
            Author = "Jane Doe",
            ItemID = 201
        };

        // TASK 3: Parent type collection
        List<lib.LibraryItem> items = new List<lib.LibraryItem>();
        items.Add(book);
        items.Add(magazine);

        foreach (lib.LibraryItem item in items)
        {
            item.Display();
            Console.WriteLine("Fees for 3 days: " + item.CalculateLateFee(3));
        }

        Console.WriteLine(
            "Method selection happens at runtime based on object type."
        );

        // TASK 4: Explicit interface implementation
        lib.IReservable reservable = book;
        reservable.ReserveItem();

        lib.INotifiable notifiable = book;
        notifiable.NotifyAvailability("Please return the book on time.");
        // TASK 6: Increase borrowed count
        LibrarySystem.LibraryAnalytics.TotalBorrowedItems += 5;

        // Display analytics
        LibrarySystem.LibraryAnalytics.DisplayAnalytics();
        // TASK 7: Assign enum values
        LibrarySystem.UserRole userRole = LibrarySystem.UserRole.Member;
        LibrarySystem.ItemStatus itemStatus = LibrarySystem.ItemStatus.Borrowed;

        // Display enum values
        Console.WriteLine("User Role: " + userRole);
        Console.WriteLine("Item Status: " + itemStatus);

    }
}
