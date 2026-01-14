using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread thread = new Thread(new ParameterizedThreadStart(PrintMessage));
        thread.Start("Hello from the thread!");
    }

    static void PrintMessage(object message)
    {
        Console.WriteLine(message);
    }
}
