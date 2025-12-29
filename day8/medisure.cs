using System;
class Medisure
{
    public string BillId;
    public string PatientName;
    public bool HasInsurance;
    public decimal ConsultationFee;
    public decimal LabCharges;
    public decimal MedicineCharges;

    public decimal GrossAmount;
    public decimal DiscountAmount;
    public decimal FinalPayable;

    public void Calculate()
{
    GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

    if (HasInsurance)
    {
        DiscountAmount = GrossAmount * 0.10m;
    }
    else
    {
        DiscountAmount = 0;
    }

    FinalPayable = GrossAmount - DiscountAmount;
}


}
class Bill
{
    public static Medisure LastBill;
    public static bool HasLastBill = false;

    public static void create()
    {
        Medisure bill = new Medisure();

        Console.Write("Enter Bill Id: ");
        bill.BillId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bill.BillId))
        {
            Console.WriteLine("Invalid Bill Id.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine();
        if(!bill.PatientName.All(Char.IsLetter))
        {
            Console.WriteLine("Patient Name must contain only letters.");
            return;
        }

        Console.Write("Is the patient insured? (Y/N): ");
        char ins = Convert.ToChar(Console.ReadLine().ToUpper());
            bill.HasInsurance = (ins == 'Y');


        Console.Write("Enter Consultation Fee: ");
        bill.ConsultationFee = Convert.ToDecimal(Console.ReadLine());
        if (bill.ConsultationFee <= 0)
        {
            Console.WriteLine("Consultation Fee must be greater than 0.");
            return;
        }

        Console.Write("Enter Lab Charges: ");
        bill.LabCharges = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = Convert.ToDecimal(Console.ReadLine());

        bill.Calculate();

        LastBill = bill;
        HasLastBill = true;

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
    }
     public static void view()
    {
        if (!HasLastBill)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine($"BillId: {LastBill.BillId}");
        Console.WriteLine($"Patient: {LastBill.PatientName}");
        Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
        Console.WriteLine("--------------------------------");
    }
    public static void clear()
    {
        HasLastBill=false;
        LastBill=null;
        Console.WriteLine("Last bill cleared.");
    }
}