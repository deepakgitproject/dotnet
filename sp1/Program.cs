// //library management using linq


// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;

// public interface IBook
// {
//     int Id { get; set; }
//     string Title { get; set; }
//     string Author { get; set; }
//     string Category { get; set; }
//     int Price { get; set; }
// }

// public interface ILibrarySystem
// {
//     void AddBook(IBook book, int quantity);
//     void RemoveBook(IBook book, int quantity);
//     int CalculateTotal();
//     List<(string, int)> CategoryTotalPrice();
//     List<(string, int, int)> BooksInfo();
//     List<(string, string, int)> CategoryAndAuthorWithCount();
// }

// public class Book : IBook
// {
//     public int Id { get; set; }
//     public string Title { get; set; }
//     public string Author { get; set; }
//     public string Category { get; set; }
//     public int Price { get; set; }
// }

// public class LibrarySystem : ILibrarySystem
// {
//     private Dictionary<IBook, int> _books;

//     public LibrarySystem()
//     {
//         _books = new Dictionary<IBook, int>();
//     }

//     public void AddBook(IBook book, int quantity)
//     {
//         if (_books.ContainsKey(book))
//             _books[book] += quantity;
//         else
//             _books.Add(book, quantity);
//     }

//     public void RemoveBook(IBook book, int quantity)
//     {
//         if (!_books.ContainsKey(book))
//             return;

//         _books[book] -= quantity;

//         if (_books[book] <= 0)
//             _books.Remove(book);
//     }

//     public int CalculateTotal()
//     {
//         return _books.Sum(b => b.Key.Price * b.Value);
//     }

//     public List<(string, int, int)> BooksInfo()
//     {
//         return _books
//             .Select(b => (b.Key.Title, b.Value, b.Key.Price))
//             .ToList();
//     }

//     public List<(string, int)> CategoryTotalPrice()
//     {
//         return _books
//             .GroupBy(b => b.Key.Category)
//             .Select(g => (
//                 g.Key,
//                 g.Sum(x => x.Key.Price * x.Value)
//             ))
//             .ToList();
//     }

//     public List<(string, string, int)> CategoryAndAuthorWithCount()
//     {
//         return _books
//             .GroupBy(b => new { b.Key.Category, b.Key.Author })
//             .Select(g => (
//                 g.Key.Category,
//                 g.Key.Author,
//                 g.Sum(x => x.Value)
//             ))
//             .ToList();
//     }
// }

// class Solution
// {
//     public static void Main(string[] args)
//     {
//         TextWriter textWriter = new StreamWriter(
//             Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//         ILibrarySystem librarySystem = new LibrarySystem();

//         int bCount = Convert.ToInt32(Console.ReadLine().Trim());

//         for (int i = 0; i < bCount; i++)
//         {
//             var a = Console.ReadLine().Trim().Split(" ");

//             IBook book = new Book
//             {
//                 Id = Convert.ToInt32(a[0]),
//                 Title = a[1],
//                 Author = a[2],
//                 Category = a[3],
//                 Price = Convert.ToInt32(a[4])
//             };

//             int quantity = Convert.ToInt32(a[5]);
//             librarySystem.AddBook(book, quantity);
//         }

//         textWriter.WriteLine("Book Info:");
//         var booksInfo = librarySystem.BooksInfo();
//         foreach (var (title, quantity, price) in booksInfo.OrderBy(x => x.Item1))
//         {
//             textWriter.WriteLine($"Book Name:{title}, Quantity:{quantity}, Price:{price}");
//         }

//         textWriter.WriteLine("Category Total Price:");
//         var categoryTotalPrice = librarySystem.CategoryTotalPrice();
//         foreach (var (category, totalPrice) in categoryTotalPrice.OrderBy(x => x.Item1))
//         {
//             textWriter.WriteLine($"Category:{category}, Total Price:{totalPrice}");
//         }

//         textWriter.WriteLine("Category And Author With Count:");
//         var categoryAuthorCount = librarySystem.CategoryAndAuthorWithCount();
//         foreach (var (category, author, count) in categoryAuthorCount.OrderBy(x => x.Item1))
//         {
//             textWriter.WriteLine($"Category:{category}, Author:{author}, Count:{count}");
//         }

//         int total = librarySystem.CalculateTotal();
//         textWriter.WriteLine($"Total Price: {total}");

//         textWriter.Flush();
//         textWriter.Close();
//     }
// }





//product inventory management


using System.CodeDom.Compiler; 
using System.Collections.Generic; 
using System.Collections; 
using System.ComponentModel; 
using System.Diagnostics.CodeAnalysis; 
using System.Globalization; 
using System.IO; 
using System.Linq; 
using System.Reflection; 
using System.Runtime.Serialization; 
using System.Text.RegularExpressions; 
using System.Text; 
using System;



public interface IProduct 
{ 
    string Name { get; set; } 
    string Category { get; set; } 
    int Stock { get; set; } 
    int Price { get; set; } 
} 
 
public interface IInventory 
{ 
    void AddProduct(IProduct product); 
    void RemoveProduct(IProduct product); 
    int CalculateTotalValue(); 
    List<IProduct> GetProductsByCategory(string category); 
    List<IProduct> SearchProductsByName(string name); 
    List<(string, int)> GetProductsByCategoryWithCount(); 
    List<(string, List<IProduct>)> GetAllProductsByCategory(); 
} 
 
class Result 
{ 
 
} 
public class Product : IProduct
{
    public string Name{get; set;}
    public string Category{get; set;}
    public int Stock{get; set;}
    public int Price{get; set;}

} 
public class Inventory : IInventory 
{ 
    private List<IProduct> _product;
    public Inventory()
    {
        _product = new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        _product.Add(product);
    }
    public void RemoveProduct(IProduct product)
    {
        
        _product.Remove(product);
    }
    public int CalculateTotalValue()
    {
        return _product.Sum(p=>p.Price * p.Stock);
    }
    public List<IProduct> GetProductsByCategory(string category)
    {
        return _product.Where(p=>p.Category == category).ToList();
    }
    public List<IProduct> SearchProductsByName(string name)
    {
        return _product.Where(p=>p.Name.Contains(name)).ToList();
    }
     public List<(string, int)> GetProductsByCategoryWithCount()
    {
        return _product
            .GroupBy(p => p.Category)
            .Select(g => (g.Key, g.Count()))
            .ToList();
    }

    public List<(string, List<IProduct>)> GetAllProductsByCategory()
    {
        return _product
            .GroupBy(p => p.Category)
            .Select(g => (g.Key, g.ToList()))
            .ToList();
    }

}         
class Solution 
{ 
    public static void Main(string[] args) 
    { 
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true); 
         
        IInventory inventory = new Inventory(); 
        int pCount = Convert.ToInt32(Console.ReadLine().Trim()); 
        for (int i = 1; i <= pCount; i++) 
        { 
            var a = Console.ReadLine().Trim().Split(" "); 
            Product e = new Product(); 
            e.Name = a[0]; 
            e.Category = a[1]; 
            e.Stock = Convert.ToInt32(a[2]); 
            e.Price = Convert.ToInt32(a[3]); 
            inventory.AddProduct(e); 
        }  
        var b = Console.ReadLine().Trim().Split(" "); 
        var randomCategoryName = b[0]; 
var randomProductName = b[1]; 
        string productName = b[2]; 
         
        var getProductsByCategory = inventory.GetProductsByCategory(randomCategoryName); 
 
        textWriter.WriteLine($"{randomCategoryName}:"); 
        foreach (var product in getProductsByCategory.OrderBy(a=>a.Name)) 
        { 
            textWriter.WriteLine($"Product Name:{product.Name} Category:{product.Category}"); 
        } 
             
        var searchProductsByName = inventory.SearchProductsByName(randomProductName); 
        textWriter.WriteLine($"{randomProductName}:"); 
        foreach (var product in searchProductsByName.OrderBy(a=>a.Name)) 
        { 
            textWriter.WriteLine($"Product Name:{product.Name} Category:{product.Category}"); 
        } 
        textWriter.WriteLine("Total Value:$" + inventory.CalculateTotalValue()); 
 
        var getProductsByCategoryWithCount = inventory.GetProductsByCategoryWithCount(); 
        foreach (var item in getProductsByCategoryWithCount.OrderBy(a=>a.Item1)) 
        { 
            textWriter.WriteLine($"{item.Item1}:{item.Item2}"); 
        } 
 
        var getAllProductsByCategory = inventory.GetAllProductsByCategory(); 
        foreach (var item in getAllProductsByCategory.OrderBy(a=>a.Item1)) 
        { 
            textWriter.WriteLine($"{item.Item1}:"); 
            foreach (var item2 in item.Item2) 
            { 
                textWriter.WriteLine($"Product Name:{item2.Name} Price:{item2.Price}"
); 
            } 
        } 
 
 
 
        var productsToDelete = inventory.SearchProductsByName(productName); 
 
        foreach (var product in productsToDelete) 
        { 
                inventory.RemoveProduct(product); 
        } 
        textWriter.WriteLine("New Total Value:$" + inventory.CalculateTotalValue());
        textWriter.Flush(); 
textWriter.Close(); 
} 
}