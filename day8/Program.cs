using System;
using System.Reflection.Metadata;
class program
{
    static void Main()
    {
        // Console.WriteLine("Hello, World!");
        // T.T1();
        // Medisure.medi();
         
        bool check  =  true;
        while (check)
        {
            Console.WriteLine("\n================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Bill.create();
                    break;
                case 2:
                    Bill.view();
                    break;
                case 3:
                    Bill.clear();
                    break;
                case 4:
                    check = false;
                    Console.WriteLine("Thank you. Application closed normally.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
                
            }
            
        }

    }
}