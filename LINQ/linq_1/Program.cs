// using System;
// using System.Collections.Generic;
// using System.Linq;

// // class Program
// // {
// //     static void Main()
// //     {
// //         int[] number  = {1,2,3,4,56,7,8};


// //         //query systax
// //         var evennumber= from n in number where n%2 == 0 select n;
// //         var evennumber = number.Where(n => n%2=0);
// //         Console.WriteLine("output of query");
// //         foreach( var n in evennumber)
// //         {
// //             Console.WriteLine(n);
// //         }
// //     }
// // }

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int>{10,20,30};

//         //deferred execution
//         var deferredquerry  = numbers.Where(n => n>15);
//         numbers.Add(50);
//         Console.WriteLine("Deferred Execution Result");
//         foreach (var item in deferredquerry)
//         {
//             Console.WriteLine(item);
//         }

//         Console.WriteLine("intermediate result");

//         var imediatequery = numbers.Where(n=>n>15).ToList();
//         numbers.Add(60);

//         foreach (var item in deferredquerry)
//         {
//             Console.WriteLine(item);
//         }
//     }
// }


// using System;
// using System.Linq;
// using System.Collections.Generic;
// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int> { 10, 20, 30, 40, 50, 60 };
//         int half = numbers.Count / 2;
//         List<int> list1=numbers.Take(half).ToList();
//         List<int> list2=numbers.Skip(half).ToList();

//         Console.WriteLine("list1:");
//         foreach(var n in list1)
//         {
//             Console.WriteLine(n); 
//         }
//         Console.WriteLine("list2:");
//         foreach(var n in list2)
//         {
//             Console.WriteLine(n);
//         }
//     }
// }


// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         ArrayList list = new ArrayList() 
//         { 
//             1, "Deepak", "Btech", 20000, 50, "Hello" 
//         };

//         IEnumerable<int> intValues = list.OfType<int>();

//         Console.WriteLine("Only integers:");

//         foreach (int i in intValues)
//         {
//             Console.WriteLine(i);
//         }
//     }
// }



using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4 };

        IEnumerable<int> result = numbers.Where(x => x > 2);

        //var result = numbers.Where(x => x > 2).ToList();

        numbers.Add(10);

        foreach (var n in result)
        {
            Console.WriteLine(n);
        }
    }
}