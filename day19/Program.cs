// using System;
// using System.Diagnostics;

// class Program
// {
//     static void Main()
//     {
//         Process currentProcess = Process.GetCurrentProcess();
//         Console.WriteLine("Current Process ID " +  currentProcess.Id);
//         Console.WriteLine("Process Name" + currentProcess.ProcessName);
//         Console.WriteLine("Start Time: " + currentProcess.StartTime);
//         Console.WriteLine("Total Threads: " + currentProcess.Threads.Count);
//         Console.WriteLine("Memory Usage: " + currentProcess.WorkingSet64 + " bytes");
//         Console.WriteLine("CPU Time: " + currentProcess.TotalProcessorTime);
//     }
// }

// using System;
// using System.Threading;



// class Program
// {
//     static void Main()
//     {
//         // Create a new thread
//         Thread worker = new Thread(DoWork);

//         // Start the thread
//         worker.Start();

//         Console.WriteLine("Main thread continues...");

//         // Optional: Wait for worker thread to finish
//         worker.Join();
//         Console.WriteLine("Main thread finished");
//     }

//     static void DoWork()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             Console.WriteLine("Worker thread: " + i);
//             Thread.Sleep(500); // Simulate work
//         }
//     }
// }

// using System.Diagnostics;
// class Program{
//     static void Main(){
//         Process.Start("cmd.exe");
//     }
// }


using System;
using System.Threading;

class Program
{
    // Shared variable between threads
    static int counter = 0;
    static object lockObj = new object();

    static void Main()
    {
        // Create two threads that run the same method
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);

        // Start both threads
        t1.Start();
        t2.Start();

        // Wait for both threads to finish
        t1.Join();
        t2.Join();

        // Print final counter value
        Console.WriteLine("Final counter value: " + counter);
    }

    // Method executed by both threads

    static void Increment()
    {
        for (int i = 0; i < 10000; i++)
        {
            lock (lockObj)
            {
                counter++;
            }
        }
    }
}