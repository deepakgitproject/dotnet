// // See https://aka.ms/new-console-template for more information
// using System.Text.RegularExpressions;
// using System;
// using LogProcessing;
// class Program
// {
//     static void Main(string[] args)
//     {

//         // Pattern	Matches
// // \d+	Digits only
// // \D+	Everything except digits
// // \w+	Letters, digits, underscore
// // \W+	Everything except \w
// // \s+	Whitespace (spaces, tabs, line breaks)
// // \S+	Everything except whitespace
//         // string sentence = "abc123";
//         // string pattern = @"\d";
//         // string sentence="123_123";
//         // string sentence="Ramu1Dosa";
//         // ^ is used for check for starting of the string and $ is used for ending of the string
//         // string pattern = @"^\d{3}_\d{3}$";
//         // string sentence="Amount : 5000";
//         // string sentence="102030abc@!";
//         //  string pattern =@"\D+";
//         // string pattern =@"\W";

//         // string pattern =@"\d*";
// // bool result = Regex.IsMatch(sentence,pattern);
// // Console.WriteLine(result);
//     // Match m = Regex.Match(sentence,pattern);
//         // Console.WriteLine(m.Value);
//     // MatchCollection matches = Regex.Matches("10 A@abc!_\t@20A@!", @"\S");
//     // foreach (Match match in matches)
// // {
//     // Console.Write(match.Value);
// // }

// // string pattern1 =@"\\";
// // string sentence1="C:\abcxyz\file.txt";
// // string pattern1 =@"\?+";
// // string sentence1="C:\abcxyz\file.txt?hello";
// // string pattern1 =@"hello$";
// // string sentence1="helloC:\abcxyz\file.txt?hello";
// // string sentence1 = "Amount : 5000";
// // string pattern1 =@"Amount=(?<value>\d+)";
// // string pattern1 =@"^hello";
// // string sentence1="helloC:\abcxyz\file.txt?hello";
// //  MatchCollection matches = Regex.Matches(sentence1, pattern1);
// //     foreach (Match match in matches)
// // {
// //     Console.Write(match.Value);
// // }

// // string sentence1 = "1992-02-23,1993-03-24,1994-01-01";
// // string sentence1 = "grappless apple grapee apple axe age";
// // string pattern1 = @"a...e";

// // string input = "23-02-1992";
// // string pattern1 = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
// // using System.Text.RegularExpressions;

// // Match m = Regex.Match(sentence1, pattern1);

// // Console.WriteLine(m.Value);
// // Console.WriteLine(m.Groups["month"].Value);
// // Console.WriteLine(m.Groups["date"].Value);
// //  MatchCollection matches = Regex.Matches(sentence1, pattern1);
// //     foreach (Match match in matches)
// // {
//     //both are correct ways to access group values
//     // Console.Write(match.Groups["year"].Value+" ");
//     // Console.Write(match.Groups[0].Value+" ");
// // }

// // using System;
// // using System.Collections.Generic;
// // using System.Text.RegularExpressions;


//         //  List<string> emails = new List<string>
//         // {
//         //     "john.doe@gmail.com",
//         //     "mark.smith@company.com",
//         //     "support@banking.co.in",
//         //     "user.name+tag@domain.org", // '+' will NOT match in this pattern
//         //     "invalid-email@",
//         //     "hello@.com"
//         // };

//         // string pattern = @"\b[\w.-]+@[\w.-]+\.\w{2,}\b";

//         // foreach (string email in emails)
//         // {
//         //     bool isValid = Regex.IsMatch(email, pattern);
//         //     Console.WriteLine($"{email} => {isValid}");
//         // }
    
//     LogParser parser = new LogParser();

//         // Task 1: Validate log line
//         string logLine1 = "[ERR] Database connection failed";
//         string logLine2 = "Database started";

//         Console.WriteLine("IsValidLine:");
//         Console.WriteLine(parser.IsValidLine(logLine1)); // true
//         Console.WriteLine(parser.IsValidLine(logLine2)); // false

//         Console.WriteLine();

//         // Task 2: Split log line using delimiters
//         string splitLog = "User<***>Login<====>Failed<^*>Again";
//         string[] parts = parser.SplitLogLine(splitLog);

//         Console.WriteLine("SplitLogLine:");
//         foreach (string part in parts)
//         {
//             Console.WriteLine(part);
//         }

//         Console.WriteLine();

//         // Task 3: Count quoted password occurrences
//         string logText = "User entered \"password123\" and \"PASSWORD456\"";
//         Console.WriteLine("CountQuotedPasswords:");
//         Console.WriteLine(parser.CountQuotedPasswords(logText)); // 2

//         Console.WriteLine();

//         // Task 4: Remove end-of-line markers
//         string eolLine = "System crash detected end-of-line45";
//         Console.WriteLine("RemoveEndOfLineText:");
//         Console.WriteLine(parser.RemoveEndOfLineText(eolLine));

//         Console.WriteLine();

//         // Task 5: Identify and label weak passwords
//         string[] logLines =
//         {
//             "User password123 failed login",
//             "System started successfully"
//         };

//         Console.WriteLine("ListLinesWithPasswords:");
//         string[] result = parser.ListLinesWithPasswords(logLines);

//         foreach (string line in result)
//         {
//             Console.WriteLine(line);
//         }

//     }
// }
using LogProcessing;
using System;   
class Program
{
    static void Main()
    {
        LogParser analyzer = new LogParser();

        // Task 1
        Console.WriteLine(analyzer.IsValidLine("[INF] Application started")); // true
        Console.WriteLine(analyzer.IsValidLine("[ABC] Unknown message"));      // false

        // Task 2
        var parts = analyzer.SplitLogLine("[INF] User login<***>Session created<====>Access granted");
        foreach (var p in parts)
            Console.WriteLine(p);

        // Task 3
        string text =
            "User said \"password123 is weak\"\n" +
            "Admin noted \"PASSWORD456 expired\"\n" +
            "No issue found";
        Console.WriteLine(analyzer.CountQuotedPasswords(text)); // 2

        // Task 4
        Console.WriteLine(
            analyzer.RemoveEndOfLineText("Transaction completed successfully end-of-line456")
        );

        // Task 5
        string[] lines =
        {
            "User entered password123 during login",
            "System startup completed",
            "Admin reset passwordABC",
            "Backup process finished"
        };

        var labeled = analyzer.ListLinesWithPasswords(lines);
        foreach (var line in labeled)
            Console.WriteLine(line);
    }
}
