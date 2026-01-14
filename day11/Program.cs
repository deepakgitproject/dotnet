// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Creating objects...");

//         for (int i = 0; i < 5; i++)
//         {
//             NewClass obj =new NewClass();
//         }

//         Console.WriteLine("Forcing GC...");
//         GC.Collect();
//         GC.WaitForPendingFinalizers();
//         Console.WriteLine("GC complete.");
//     }
// }

// class NewClass
// {
//     ~NewClass()
//     {
//         Console.WriteLine("Finalizer called, object collected");
//     }
// }
using System;
using System.Linq;
class Program
{
    static void Main()
    {


    //     Console.WriteLine("Creating objects...");

    //     CreateObjects();   

    //     Console.WriteLine("Forcing GC...");
    //     GC.Collect();
    //     GC.WaitForPendingFinalizers();
    //     GC.Collect();      

    //     Console.WriteLine("GC complete.");
    // }

    // static void CreateObjects()
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         NewClass obj = new NewClass();
    //     }



        // (int, string) studentl =(101 ," Amit" ) ;
        // Console.WriteLine($"Student ID: {studentl.Item1}, Name: {studentl.Item2}");

        // var Student =new {Id = 102, Name = "Suman"};
        // Console.WriteLine($"Student ID: {Student.Id}, Name: {Student.Name}");
        // Console.WriteLine(studentl.GetType());
        // Console.WriteLine(Student.GetType());

        int[] number = {11,12,03,114,5};
        var assendingnumber = number.OrderBy(n=>n);
        foreach(var num in assendingnumber)
        {
            Console.WriteLine(num);
        }
        var evennumbers = number.Where(n=>n%2==0);
        evennumbers.GetType();

        Console.WriteLine("even numbers:");
        foreach(var num in evennumbers)
        {
            Console.WriteLine(num);
        }
    }
}

// class NewClass
// {
//     ~NewClass()
//     {
//         Console.WriteLine("Finalizer called, object collected");
//     }
// }
