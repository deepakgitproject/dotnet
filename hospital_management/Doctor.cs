 namespace IHCMS
{
class Doctor
    {
        public static int TotalDoctors;
        public readonly string LicenseNumber;

        public string Name { get; set; }
        public string Specialization { get; set; }

        static Doctor()
        {
            TotalDoctors = 0;
        }

        public Doctor(string name, string specialization, string license)
        {
            Name = name;
            Specialization = specialization;
            LicenseNumber = license;
            TotalDoctors++;
        }
    }

     class Cardiologist : Doctor
{
    public int YearsOfExperience { get; set; }

    // Call to parent class constructor using base
    public Cardiologist(
        string name,
        string license,
        int experience
    ) : base(name, "Cardiology", license)
    {
        YearsOfExperience = experience;
    }

    public void PrintDetails()
    {
        // Print static member
        Console.WriteLine("Total Doctors: " + Doctor.TotalDoctors);

        // Print non-static members
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Specialization: " + Specialization);
        Console.WriteLine("License Number: " + LicenseNumber);
        Console.WriteLine("Experience: " + YearsOfExperience + " years");
    }
}
}