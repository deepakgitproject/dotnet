using System;
using System.Collections.Generic;

class Library
{
    private Dictionary<int, string> books = new Dictionary<int, string>();

    public string this[int bookId]
    {
        get
        {
            if (books.ContainsKey(bookId))
                return books[bookId];

            return "Book ID not found";
        }
        set
        {
            books[bookId] = value;
        }
    }

    public string this[string title]
    {
        get
        {
            foreach (var book in books)
            {
                if (book.Value == title)
                    return book.Value;
            }
            return "Book title not found";
        }
    }
}

