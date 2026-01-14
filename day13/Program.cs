// using System;
// delegate void PaymentDelegate(decimal amount);
// class PaymentService
// {
//     public void ProcessPayment(decimal amount)
//     {
//         Console.WriteLine("payment of "+amount+" processed successfully");
//     }
//     public void update(decimal amount)
//     {
//         Console.WriteLine("balance of "+amount+" updated successfully");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         PaymentService service = new PaymentService();
//         // PaymentDelegate payment = service.ProcessPayment;
//         PaymentDelegate payment = null;
//         payment += service.ProcessPayment;
//         payment += service.update;

        
//         // payment(5000);

//         decimal amount = 5000;
//         if (amount.isValidPayment())
//         {
//             payment(amount);
//         }else
//         {
//             Console.WriteLine("Payment invalid");
//         }
//     }
// }
// static class PaymentExtention
// {
//     public static bool isValidPayment(this decimal amount)
//     {
//         return amount>0 && amount<=1000000;
//     }
// }



// using System;

// class Program
// {
//     delegate void LogActivity(string message);

//     static void Main()
//     {
//         LogActivity logActivity = message =>
//         {
//             Console.WriteLine("Log Entry: " + message);
//         };

//         logActivity("User logged in at 10:30 AM");
//     }
// }



// using System;
// class Program
// {
//     static void Main()
//     {
//         Func<decimal,decimal,decimal>calculateDiscount = 
//         (price,discount) => price - (price*discount/100);

//         Predicate<int> iseligible = age =>age>=18;
//         Console.WriteLine(iseligible(20));

//         Console.WriteLine(calculateDiscount(1000,10));
//     }
// }



// using System;

// // Step 1: Declare delegate
// delegate void ErrorDelegate(string message);

// class Program
// {
//     static void Main()
//     {
//         // Step 2: Create delegate using anonymous method
//         ErrorDelegate errorHandler = delegate (string msg)
//         {
//             Console.WriteLine("Error: " + msg);
//         };

//         // Step 3: Call the delegate
//         errorHandler("File not found");
//     }
// }



// using System;

// class Button
// {
//     // Step 1: Declare a delegate
//     public delegate void ClickHandler();

//     // Step 2: Declare an event using the delegate
//     public event ClickHandler Clicked;

//     // Step 3: Method that raises the event
//     public void Click()
//     {
//         Clicked?.Invoke();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Button btn = new Button();

//         // Step 4: Subscribe a method to the event
//         btn.Clicked += () => Console.WriteLine("Button was clicked");
//         btn.Clicked += () => Console.WriteLine("Logging button click event");
//         btn.Clicked += () => Console.WriteLine("Performing action on button click");

//         // Step 5: Trigger the event
//         btn.Click();
//     }
// }






//one delegate multiple event


// using System;

// class Button
// {
//     // One delegate with NO parameters
//     public delegate void ButtonEventHandler();

//     // Two events using the SAME delegate
//     public event ButtonEventHandler Clicked;
//     public event ButtonEventHandler Hovered;

//     // Raise Clicked event
//     public void Click()
//     {
//         Clicked?.Invoke();
//     }

//     // Raise Hovered event
//     public void Hover()
//     {
//         Hovered?.Invoke();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Button btn = new Button();

//         // Same handler subscribed to BOTH events
//         btn.Clicked += OnButtonAction;
//         btn.Hovered += OnButtonAction;

//         btn.Click();
//         btn.Hover();
//     }

//     static void OnButtonAction()
//     {
//         Console.WriteLine("Button event occurred");
//     }
// }




// using System;

// class Downloader
// {
//     // Step 1: Declare delegate
//     public delegate void DownloadDelegate();

//     // Step 2: Declare event
//     public event DownloadDelegate DownloadCompleted;

//     // Step 3: Raise event
//     public void CompleteDownload()
//     {
//         DownloadCompleted?.Invoke();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Downloader d = new Downloader();

//         // Subscribe to event
//         d.DownloadCompleted += () =>
//             Console.WriteLine("Download completed");

//         // Trigger event
//         d.CompleteDownload();
//     }
// }






// using System;
// using System.Collections.Generic;

// namespace SmartHomeSecurity
// {
//     // 1. DEFINITION: The "Contract" for any security response.
//     // Any method responding to an alert must be void and take a string location.

//     public delegate void SecurityAction(string zone); // definition

//     public class MotionSensor
//     {
//         // The delegate instance (The Panic Button)
//         public SecurityAction OnEmergency; // instance creation

//         public void DetectIntruder(string zoneName)
//         {
//             Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");
            
//             // 3. INVOCATION: Triggering the Panic Button
//             if (OnEmergency != null)
//             {
//                 OnEmergency(zoneName); // string value = Main Lobby or panicSequence?
//             }
//         }
//     }

//     // Diverse classes that don't know about each other
//     public class AlarmSystem
//     {
//         public void SoundSiren(string zone) => Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
//     }

//     public class PoliceNotifier
//     {
//         public void CallDispatch(string zone) => Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
//     }

//     class Program
//     {
//         static void Main()
//         {
//             // Objects Initialization
//             MotionSensor livingRoomSensor = new MotionSensor();
//             AlarmSystem siren = new AlarmSystem();
//             PoliceNotifier police = new PoliceNotifier();

//             // 2. INSTANTIATION & MULTICASTING
//             // We "Subscribe" different methods to the sensor's delegate
//             SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
//             panicSequence += police.CallDispatch;

//             // Linking the sequence to the sensor
//             livingRoomSensor.OnEmergency = panicSequence;
// 	// class_object.delegate_instance = delegate_instance_multicast

//             // Simulation
//             livingRoomSensor.DetectIntruder("Main Lobby");
//         }
//     }
// }





// using System;
// using System.Threading;

// namespace CallbackDemo
// {
//     // STEP 1: Define the Delegate
//     public delegate void DownloadFinishedHandler(string fileName);

//     class FileDownloader
//     {
//         // STEP 2: Method that accepts the callback
//         public void DownloadFile(string name, DownloadFinishedHandler callback)
//         {
//             Console.WriteLine($"Starting download: {name}...");
            
//             // Simulating work
//             // Thread.Sleep(2000); 
            
//             Console.WriteLine($"{name} download complete.");

//             // STEP 3: Execute the Callback
//             if (callback != null)
//             {
//                 callback(name); 
//             }
//         }
//     }

//     class Program
//     {
//         // STEP 4: The actual Callback Method
//         static void DisplayNotification(string file)
//         {
//             Console.WriteLine($"NOTIFICATION: You can now open {file}.");
//         }

//         static void Main()
//         {
//             FileDownloader downloader = new FileDownloader();

//             // Pass the method 'DisplayNotification' as a callback
//             downloader.DownloadFile("Presentation.pdf", DisplayNotification);
//             Comparison<int> sortDescending = (a, b) => b.CompareTo(a) ;
//             Console.WriteLine(sortDescending(8,2));//only int and char will work

//         }
//     }
// }