using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{  
    // Hardcoded item details (already provided in template)
    public static SortedDictionary<string, long> itemDetails =
        new SortedDictionary<string, long>() {
            { "Pen", 150 },
            { "Notebook", 300 },
            { "Pencil", 100 },
            { "Eraser", 50 }
        };

    // Find item details by sold count
    public static SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result = new SortedDictionary<string, long>();

        foreach (var item in itemDetails)
        {
            if (item.Value == soldCount)
            {
                result.Add(item.Key, item.Value);
            }
        }

        return result;
    }

    // Find minimum and maximum sold items
    public static List<string> FindMinandMaxSoldItems()
    {
        List<string> result = new List<string>();

        long minValue = itemDetails.Min(i => i.Value);
        long maxValue = itemDetails.Max(i => i.Value);

        string minItem = itemDetails.First(i => i.Value == minValue).Key;
        string maxItem = itemDetails.First(i => i.Value == maxValue).Key;

        result.Add(minItem);
        result.Add(maxItem);

        return result;
    }

    // Sort items by sold count
    public static Dictionary<string, long> SortByCount()
    {
        Dictionary<string, long> sortedResult =
            itemDetails.OrderBy(i => i.Value)
                       .ToDictionary(i => i.Key, i => i.Value);

        return sortedResult;
    }

    static void Main(string[] args)
    {
        // Hardcoded sold count
        long soldCount = 100;

        // Call FindItemDetails
        SortedDictionary<string, long> foundItems = FindItemDetails(soldCount);

        if (foundItems.Count == 0)
        {
            Console.WriteLine("Invalid sold count");
        }
        else
        {
            Console.WriteLine("Item Details:");
            foreach (var item in foundItems)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        // Find minimum and maximum sold items
        List<string> minMaxItems = FindMinandMaxSoldItems();
        Console.WriteLine("Minimum Sold Item: " + minMaxItems[0]);
        Console.WriteLine("Maximum Sold Item: " + minMaxItems[1]);

        // Sort items by sold count
        Dictionary<string, long> sortedItems = SortByCount();
        Console.WriteLine("Items Sorted by Sold Count:");
        foreach (var item in sortedItems)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}

/*
▶️ Sample Execution

Output:
Item Details:
Pencil : 100
Minimum Sold Item: Eraser
Maximum Sold Item: Notebook
Items Sorted by Sold Count:
Eraser : 50
Pencil : 100
Pen : 150
Notebook : 300
*/
