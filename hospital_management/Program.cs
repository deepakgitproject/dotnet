using System;

using IHCMS;

    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Welcome to {HospitalSystem.HospitalName}\n");

            // Patient
            Patient p = new Patient(1, "Rahul", 45);
            p.SetMedicalHistory("Hypertension");

            // Doctor
            Doctor d = new Doctor("Meera", "Cardiology", "DOC-4589");

            // Appointment
            Appointment.Schedule(p, d, DateTime.Now, "Online");

            // Diagnosis
            string condition = "Stable";
            DiagnosisService.Evaluate(
                p.Age,
                ref condition,
                out string risk,
                90, 85, 95
            );

            Console.WriteLine($"Condition: {condition}");
            Console.WriteLine($"Risk Level: {risk}");

            // Billing
            Bill bill = new Bill
            {
                ConsultationFee = 700,
                TestCharges = 2200,
                RoomCharges = 4000
            };

            Console.WriteLine($"Total Bill: {bill.Total()}");

            // Insurance
            double finalAmount = InsuranceService.ApplyCoverage(bill.Total(), 20);
            Console.WriteLine($"Final Payable Amount (After Insurance): {finalAmount}");

            // Recursion demo
            int stayDays = StayCalculator.CalculateStayDays(5);
            Console.WriteLine($"Hospital Stay Days: {stayDays}");

            Console.WriteLine($"\nTotal Doctors Registered: {Doctor.TotalDoctors}");
            Cardiologist c1 = new Cardiologist(
            "Dr. Meera",
            "CARD-9012",
            12
        );

        c1.PrintDetails();
        }
    }

