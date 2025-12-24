using System;

namespace LibrarySystem
{
    namespace Items
    {
        abstract class LibraryItem
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int ItemID { get; set; }

            public abstract void Display();
            public abstract double CalculateLateFee(int day);
        }

        interface IReservable
        {
            void ReserveItem();
        }

        interface INotifiable
        {
            void NotifyAvailability(string message);
        }

        class Book : LibraryItem, IReservable, INotifiable
        {
            public override void Display()
            {
                Console.WriteLine("Item Type: Book");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double CalculateLateFee(int day)
            {
                return day * 1.0;
            }

            void IReservable.ReserveItem()
            {
                Console.WriteLine("Book reserved successfully");
            }

            void INotifiable.NotifyAvailability(string message)
            {
                Console.WriteLine("Notification: " + message);
            }
        }

        class Magazine : LibraryItem
        {
            public override void Display()
            {
                Console.WriteLine("Item Type: Magazine");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double CalculateLateFee(int day)
            {
                return day * 0.5;
            }
        }
    }

    //  TASK 5: Users namespace
    namespace Users
    {
        class Member
        {
            public string Name { get; set; }
        }
    }
}
    namespace LibrarySystem
{
    enum UserRole
    {
        Admin,
        Librarian,
        Member
    }

    enum ItemStatus
    {
        Available,
        Borrowed,
        Reserved,
        Lost
    }
}



