// using System;
// class T
// {
//     public static void T1()
//     {
//         Console.WriteLine("Enter the number of products:");
//         int a = Convert.ToInt32(Console.ReadLine());
//         int [] arr = new int[a];
//         int n=0;
//         int sum=0;
//         while(n<a){
//             int s = Convert.ToInt32(Console.ReadLine());
//             if (s < 0)
//             {
//                 Console.WriteLine("You should Enter only positive number:");
//             }else
//             {
//                 sum+=s;
//                 arr[n]=s;
//                 n++;
//             }

//         }
//         int avg = sum/a;
//         Console.WriteLine($"Average Price of your Product are: {avg}");
//         Console.WriteLine(String.Join(" ",arr));
//         Console.WriteLine();

//         Array.Sort(arr);
//         for(int i=0; i<a; i++)
//         {
//             if (arr[i] < avg)
//             {
//                 arr[i]=0;
//             }
//         }
//         Array.Resize(ref arr, a+5);
//         for(int i=a; i<a+5; i++)
//         {
//             arr[i]=avg;
//         }
//         Console.WriteLine(String.Join(" ",arr));

//     }
// }