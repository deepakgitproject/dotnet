// using System;
// using System.IO;

// class User
// {
//     public int id;
//     public string name;
// }
// class Program
// {
//     static void Main()
//     {
//     //     string filepath = "data2.txt";
//     //     File.WriteAllText(filepath, "Hello, World!");
//     //     Console.WriteLine("File written successfully.");

//     //     string content = File.ReadAllText(filepath);
//     //     Console.WriteLine("file content");
//     //     Console.WriteLine(content);

//     // using (StreamWriter writer = new StreamWriter("log.txt"))
//     //     {
//     //         writer.WriteLine("Application Started");
//     //         writer.WriteLine("Processing data");
//     //         writer.WriteLine("Application ended");
//     //     }
//     //     using (StreamReader reader = new StreamReader("log.txt"))
//     //     {
//     //         String line;
//     //         while((line = reader.ReadLine()) != null)
//     //         {
//     //             Console.WriteLine(line);
//     //         }
//     //     }
//     //   User user = new User {id = 1, name = "Alice"};
//     //     using(StreamWriter writer = new StreamWriter("log.txt"))
//     //     {
//     //         writer.WriteLine(user.id);
//     //         writer.WriteLine(user.name);
//     //         user.id = 2;
//     //         user.name = "Bob";
//     //         writer.WriteLine(user.id);
//     //         writer.WriteLine(user.name);
//     //     }
//     //     Console.WriteLine("Done");
//         // User user = new User();
//         // using (StreamReader reader = new StreamReader("log.txt"))
//         // {
//         //     user.id = int.Parse(reader.ReadLine());
//         //     user.name = reader.ReadLine();
//         // }
//         // Console.WriteLine($"User Loaded: {user.id} ,{user.name}");

//         User user  = new User{id = 2, name = "bob"};
//         using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
//         {
//             writer.Write(user.id);
//             writer.Write(user.name);
//         }
//         Console.WriteLine("User saved to binary file.");
//     }
// }



// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         FileInfo file = new FileInfo("sample.txt");

//         if (!file.Exists)
//         {
//             using (StreamWriter writer = file.CreateText())
//             {
//                 writer.WriteLine("Hello FileInfo Class");
//             }
//         }

//         Console.WriteLine("File Name: " + file.Name);
//         Console.WriteLine("File Size: " + file.Length + " bytes");
//         Console.WriteLine("Created On: " + file.CreationTime);
//     }
// }

//create directory
// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         Directory.CreateDirectory("Logs");

//         if (Directory.Exists("Logs"))
//         {
//             Console.WriteLine("Logs directory created successfully.");
//         }
//     }
// }




//
// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         DirectoryInfo dir = new DirectoryInfo("Logs");

//         if (!dir.Exists)
//         {
//             dir.Create();
//         }

//         Console.WriteLine("Directory Name: " + dir.Name);
//         Console.WriteLine("Created On: " + dir.CreationTime);
//         Console.WriteLine("Full Path: " + dir.FullName);
//     }
// }



// using System;
// using System.IO;
// using System.Text.Json;

// class Program
// {
//     static void Main()
//     {
//         User user = new User { id = 2, name = "ramudosaiisi" };

//         string json = JsonSerializer.Serialize(user);

//         File.AppendAllText("user.json", json);

//         Console.WriteLine("User serialized successfully");
//     }
// }

// class User
// {
//     public int id { get; set; }
//     public string name { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         string json = File.ReadAllText("user.json");

//         User user = JsonSerializer.Deserialize<User>(json);

//         Console.WriteLine($"User Loaded: {user.id}, {user.name}");
//     }
// }

using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class User
{
    public int Id;
    public string Name;
}
class Program
{
    static void Main()
    {
        User user = new User { Id = 1, Name = "Alice" };
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs, user);
        }

        Console.WriteLine("XML Serialized "+typeof(User));
    }
}
