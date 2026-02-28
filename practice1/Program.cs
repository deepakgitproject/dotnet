// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Cryptography.X509Certificates;

// public interface IStudentManager
// {
//     void AddStudent(string name, int marks);
//     int GetMarks(string name);
//     List<string> GetAllStudents();
//     double GetAverageMarks();
// }
// class Student:IStudentManager
// {
//     private Dictionary<string, int> students = new Dictionary<string, int>();
//     public void AddStudent(string name, int marks)
//     {
//         if (students.ContainsKey(name))
//         {
//             students[name]=marks;
//         }
//         else
//         {
//             students.Add(name,marks);
//         }
//     }

//     public int GetMarks(string name)
//     {
//         return students.ContainsKey(name) ? students[name] :-1;
//     }
//     public List<string> GetAllStudents()
//     {
//         return students.Keys.OrderBy(x=>x).ToList();
//     }
//     public double GetAverageMarks()
//     {
//         // return students.Avg(n=>n.marks);
//         return students.Values.Average();
//     }
// }
// class Program
// {
//     static void Main(){
//     Student c = new Student();

//         c.AddStudent("Deepak",100);
//         c.AddStudent("roughan",90);
//         c.AddStudent("mohan",60);
//     Console.WriteLine(c.GetMarks("Deepak"));
//     var a= c.GetAllStudents();
//     foreach(var v in a)
//     {
//         Console.WriteLine(v);
//     }
//     Console.WriteLine(c.GetAverageMarks());
// }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;

// public interface IInventoryManager
// {
//     void AddProduct(string name, int quantity);
//     void RemoveProduct(string name, int quantity);
//     int GetQuantity(string name);
//     List<string> GetLowStockProducts(int threshold);
// }
// class InventoryManager:IInventoryManager
// {
//     private Dictionary<string,int> dic = new Dictionary<string, int>();
//     public void AddProduct(string name, int quantity)
//     {
//             dic[name] = quantity;
//     }
//     public void RemoveProduct(string name, int quantity)
//     {
//         if (dic.ContainsKey(name))
//         {
//             if (dic[name] >= quantity)
//             {
//                 dic[name] -= quantity;
//             }
//         }

//     }
//     public int GetQuantity(string name)
//     {
//         return dic.ContainsKey(name) ? dic[name]:0;
//     }
//     public List<string> GetLowStockProducts(int threshold)
//     {
//         return  dic.Where(n=>n.Value<threshold).Select(n=>n.Key).ToList();
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         IInventoryManager manager = new InventoryManager();

//         int n = int.Parse(Console.ReadLine());

//         for (int i = 0; i < n; i++)
//         {
//             string input = Console.ReadLine();
//             var parts = input.Split(' ');

//             if (parts[0] == "Add")
//             {
//                 string name = parts[1];
//                 int qty = int.Parse(parts[2]);
//                 manager.AddProduct(name, qty);
//             }
//             else if (parts[0] == "Remove")
//             {
//                 string name = parts[1];
//                 int qty = int.Parse(parts[2]);
//                 manager.RemoveProduct(name, qty);
//             }
//             else if (parts[0] == "Get")
//             {
//                 string name = parts[1];
//                 Console.WriteLine(manager.GetQuantity(name));
//             }
//             else if (parts[0] == "LowStock")
//             {
//                 int threshold = int.Parse(parts[1]);
//                 var result = manager.GetLowStockProducts(threshold);

//                 foreach (var item in result)
//                 {
//                     Console.WriteLine(item);
//                 }
//             }
//         }
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;
// public interface IBankManager
// {
//     void CreateAccount(string accountNumber);
//     void Deposit(string accountNumber, decimal amount);
//     void Withdraw(string accountNumber, decimal amount);
//     decimal GetBalance(string accountNumber);
//     string GetRichestAccount();
// }
// class BankManager:IBankManager
// {
//     private Dictionary<string, decimal> nv = new Dictionary<string, decimal>();

//     public void CreateAccount(string accountNumber)
//     {
//         if(!nv.ContainsKey(accountNumber))
//         {
//             nv[accountNumber] = 0;
//         }
//     }


    
//     public void Deposit(string accountNumber, decimal amount)
//     {
//         nv[accountNumber]+=amount;
//     }


//     public void Withdraw(string accountNumber, decimal amount)
//     {
//         nv[accountNumber] -=amount;
//     }
//     public decimal GetBalance(string accountNumber)
//     {
        
//     }
//     public string GetRichestAccount()
//     {
        
//     }
// }




