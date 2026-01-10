<<<<<<< HEAD
using System;
using System.Collections.Generic;
namespace DialingCodesApp
{
    public static class DialingCodes
    {

        //##### Task 1: Create an Empty Dialing Code Dictionary
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        //### Task 2: Create a Dictionary with Predefined Country Codes
        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>()
            {
                { 1 ,"United States of America"},
                {55 ,"Brazil"}, 
                {91 ,"India" }
            };
        }
        //### Task 3: Add a Country to an Empty Dictionary
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(countryCode, countryName);
            return dict;
        }

        //### Task 4: Add a Country to an Existing Dictionary
        public static Dictionary<int, string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        //### Task 5: Retrieve a Country Name Using Country Code
        public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
                return existingDictionary[countryCode];

            return "";
        }
        
        //### Task 6: Check if a Country Code Exists
        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

        //### Task 7: Update an Existing Country Name
        public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode]=countryName;
            }
            return existingDictionary;
        }

        //### Task 8: Remove a Country from Dictionary
        public static Dictionary<int, string> RemoveCountryFromDictionary(Dictionary<int, string> existingDictionary,int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }

        //### Task 9: Find the Longest Country Name
        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            string longestName = "";
            foreach(var item in existingDictionary)
            {
                if (item.Value.Length > longestName.Length)
                {
                    longestName = item.Value;
                }
            }
            return longestName;
        }
    }

class Program1
{
    static void calculate()
    {
        Dictionary<int,string> emptydict=DialingCodes.GetEmptyDictionary();
        Dictionary<int,string> existingDict =DialingCodes.GetExistingDictionary();
        Dictionary<int,string> singleEntryDict=DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
        DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");
        string country91=DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
        bool is55Exists=DialingCodes.CheckCodeExists(existingDict, 55);
        DialingCodes.UpdateDictionary(existingDict, 55, "Federative Republic of Brazil");
        DialingCodes.RemoveCountryFromDictionary(existingDict, 1);
        string longestName=DialingCodes.FindLongestCountryName(existingDict);

        Console.WriteLine("Country with code 91: " + country91);
        Console.WriteLine("Does code 55 exist: " + is55Exists);
        Console.WriteLine("Longest country name: " + longestName);
    }
}

=======
using System;
using System.Collections.Generic;
namespace DialingCodesApp
{
    public static class DialingCodes
    {

        //##### Task 1: Create an Empty Dialing Code Dictionary
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        //### Task 2: Create a Dictionary with Predefined Country Codes
        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>()
            {
                { 1 ,"United States of America"},
                {55 ,"Brazil"}, 
                {91 ,"India" }
            };
        }
        //### Task 3: Add a Country to an Empty Dictionary
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(countryCode, countryName);
            return dict;
        }

        //### Task 4: Add a Country to an Existing Dictionary
        public static Dictionary<int, string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            existingDictionary[countryCode] = countryName;
            return existingDictionary;
        }

        //### Task 5: Retrieve a Country Name Using Country Code
        public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
                return existingDictionary[countryCode];

            return "";
        }
        
        //### Task 6: Check if a Country Code Exists
        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int
countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

        //### Task 7: Update an Existing Country Name
        public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int
countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode]=countryName;
            }
            return existingDictionary;
        }

        //### Task 8: Remove a Country from Dictionary
        public static Dictionary<int, string> RemoveCountryFromDictionary(Dictionary<int, string> existingDictionary,int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }

        //### Task 9: Find the Longest Country Name
        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            string longestName = "";
            foreach(var item in existingDictionary)
            {
                if (item.Value.Length > longestName.Length)
                {
                    longestName = item.Value;
                }
            }
            return longestName;
        }
    }

class Program1
{
    static void calculate()
    {
        Dictionary<int,string> emptydict=DialingCodes.GetEmptyDictionary();
        Dictionary<int,string> existingDict =DialingCodes.GetExistingDictionary();
        Dictionary<int,string> singleEntryDict=DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
        DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");
        string country91=DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
        bool is55Exists=DialingCodes.CheckCodeExists(existingDict, 55);
        DialingCodes.UpdateDictionary(existingDict, 55, "Federative Republic of Brazil");
        DialingCodes.RemoveCountryFromDictionary(existingDict, 1);
        string longestName=DialingCodes.FindLongestCountryName(existingDict);

        Console.WriteLine("Country with code 91: " + country91);
        Console.WriteLine("Does code 55 exist: " + is55Exists);
        Console.WriteLine("Longest country name: " + longestName);
    }
}

>>>>>>> c45fc69d5fbdbfb4fff8724ca36ffc9b5e9691a5
}