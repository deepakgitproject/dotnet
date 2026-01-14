using System.Text;




class Program
{
    static void Main()
    {
//         Console.WriteLine(GC.GetTotalMemory(true));
// StringBuilder sb = new StringBuilder();
// for (int i = 0; i < 100000; i++)
// {
//     sb.Append("Hello World");
// }
// Console.WriteLine(GC.GetTotalMemory(false));
// string sb ="";
// sb.Append("hello world");
// sb.AppendLine();
// sb.Append(" ");
// sb.Append("world");
// sb.Insert(5, ",");
// sb.Replace("world", "C#");
// sb.Remove(0, 6);
// sb.Clear();
// sb.Append("Goodbye C#").AppendLine().Append("See you later!").Replace("C#", "everyone");
// Console.WriteLine(sb.ToString());




    StringBuilder sb1 = new StringBuilder("Hello World");
        StringBuilder sb2 = new StringBuilder("Hello World");

        Console.WriteLine(sb1.Equals(sb2));                 // true
        Console.WriteLine(object.ReferenceEquals(sb1, sb2)); // False
        Console.WriteLine(sb1 == sb2);                      // False

        string st1 = "Hello World";
        string st2 = "Hello World";

        Console.WriteLine(st1.Equals(st2));                 // True
        Console.WriteLine(object.ReferenceEquals(st1, st2)); // True (string interning)
        Console.WriteLine(st1 == st2);                      // True

        StringBuilder sb3 = sb1;
        Console.WriteLine(sb1.Equals(sb3));
         Console.WriteLine(sb1 == sb3);                      // False


    }
}