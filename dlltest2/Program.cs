using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Load the DLL
        Assembly asm = Assembly.LoadFrom(@"C:\A_Computer_Main\main\all_work\vs-studio-saves\dotnet\dlltest1\bin\Debug\net10.0\dlltest1.dll"); 

        Console.WriteLine("Assembly Loaded: " + asm.FullName);
        Console.WriteLine();

        // Get all types (classes & interfaces)
        Type[] types = asm.GetTypes();

        foreach (Type t in types)
        {
            Console.WriteLine("Type Name: " + t.FullName);

            // Check if interface
            if (t.IsInterface)
            {
                Console.WriteLine(" --> This is an Interface");
            }
            else if (t.IsClass)
            {
                Console.WriteLine(" --> This is a Class");
            }

            // List methods
            Console.WriteLine(" Members:");
            MethodInfo[] methods = t.GetMethods();

            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("    " + m.Name);
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}
