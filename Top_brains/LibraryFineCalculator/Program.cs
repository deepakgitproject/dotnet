using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    static List<dynamic> books = new List<dynamic>();

    public static void Main()
    {
        // Admin operations
        AddBook(1, "C# Basics", "TechPress", 500);
        AddBook(2, "ASP.NET Core", "Microsoft", 800);
        AddBook(3, "Data Structures", "Pearson", 650);

        UpdateBook(2, "ASP.NET Core MVC", "Microsoft", 900);
        DeleteBook(1);

        Console.WriteLine("=== ALL BOOKS ===");
        ViewAllBooks();

        Console.WriteLine("\n=== SEARCH BY NAME ===");
        SearchByName("Data Structures");

        Console.WriteLine("\n=== SEARCH BY PUBLISHER ===");
        SearchByPublisher("Microsoft");

        Console.WriteLine("\n=== HIGHEST PRICE BOOK ===");
        ShowHighestPriceBook();

        Console.WriteLine("\n=== LOWEST PRICE BOOK ===");
        ShowLowestPriceBook();
    }

    // Admin: Add Book
    static void AddBook(int id, string name, string publisher, double price)
    {
        dynamic book = new
        {
            Id = id,
            Name = name,
            Publisher = publisher,
            Price = price
        };
        books.Add(book);
    }

    // Admin: Update Book
    static void UpdateBook(int id, string name, string publisher, double price)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Id == id)
            {
                books[i] = new
                {
                    Id = id,
                    Name = name,
                    Publisher = publisher,
                    Price = price
                };
                break;
            }
        }
    }

    // Admin: Delete Book
    static void DeleteBook(int id)
    {
        books.RemoveAll(b => b.Id == id);
    }

    // Admin/User: View All Books
    static void ViewAllBooks()
    {
        foreach (var book in books)
        {
            DisplayBook(book);
        }
    }

    // User: Search by Name
    static void SearchByName(string name)
    {
        foreach (var book in books.Where(b => b.Name == name))
        {
            DisplayBook(book);
        }
    }

    // User: Search by Publisher
    static void SearchByPublisher(string publisher)
    {
        foreach (var book in books.Where(b => b.Publisher == publisher))
        {
            DisplayBook(book);
        }
    }

    // User: Highest Price Book
    static void ShowHighestPriceBook()
    {
        var book = books.OrderByDescending(b => b.Price).FirstOrDefault();
        if (book != null)
            DisplayBook(book);
    }

    // User: Lowest Price Book
    static void ShowLowestPriceBook()
    {
        var book = books.OrderBy(b => b.Price).FirstOrDefault();
        if (book != null)
            DisplayBook(book);
    }

    // Helper method
    static void DisplayBook(dynamic book)
    {
        Console.WriteLine($"Id: {book.Id}, Name: {book.Name}, Publisher: {book.Publisher}, Price: {book.Price}");
    }
}

/*
▶️ Sample Execution

Output:
=== ALL BOOKS ===
Id: 2, Name: ASP.NET Core MVC, Publisher: Microsoft, Price: 900
Id: 3, Name: Data Structures, Publisher: Pearson, Price: 650

=== SEARCH BY NAME ===
Id: 3, Name: Data Structures, Publisher: Pearson, Price: 650

=== SEARCH BY PUBLISHER ===
Id: 2, Name: ASP.NET Core MVC, Publisher: Microsoft, Price: 900

=== HIGHEST PRICE BOOK ===
Id: 2, Name: ASP.NET Core MVC, Publisher: Microsoft, Price: 900

=== LOWEST PRICE BOOK ===
Id: 3, Name: Data Structures, Publisher: Pearson, Price: 650
*/
