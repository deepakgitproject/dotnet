using System;
using System.ComponentModel;
namespace day4
{
    class EmployeeDirectory
{
    private Dictionary<int, string> employees = new Dictionary<int, string>();

    public string this[int id]
    {
        get { return employees[id]; }
        set { employees[id] = value; }
    }

    public string this[string name]
    {
        get
        {
            return employees.FirstOrDefault(e => e.Value == name).Value;
        }
    }
}
class Person
{
    public string Name;

    public Person(string name)
    {
        Name = name;
    }
}

class Student : Person
{
    public int RollNo;

    public Student(string name, int roll) : base(name)
    {
        RollNo = roll;
    }
}
class LivingBeing
{
    public void Breathe()
    {
        Console.WriteLine("Breathing");
    }
}

class Human : LivingBeing
{
    public void Think()
    {
        Console.WriteLine("Thinking");
    }
}

class Employee : Human
{
    public void Work()
    {
        Console.WriteLine("Working");
    }
}
    class Program
    {
        
        static void Main(){
        //     Employee emp = new Employee();
        //     emp.Breathe();
        //     emp.Think();
        //     emp.Work();

            // Student student = new Student("Ramu", 24);
            // Console.WriteLine("Name: " + student.Name + ", Roll No: " + student.RollNo);
        // EmployeeDirectory ed = new EmployeeDirectory();
        // ed[101] = "Alice";
        // ed[102] = "Bob";    

        // Console.WriteLine(ed[101]);
        // Console.WriteLine(ed["Alice"]);
        // {
        //     Student student = new Student();
        //     student.name = "Ramu"; 
        //     student.age = "24";// Using Auto-Implemented Property
        //     student.marks = "85";
        //     student.password = "dosa";
        //     student.StudentId();
        // }
        //  Library library = new Library();

        // // Add books using integer indexer
        // library[101] = "C# Basics";
        // library[102] = "OOP in C#";
        // library[103] = "Advanced .NET";

        // // Retrieve using Book ID
        // Console.WriteLine(library[101]);
        // Console.WriteLine(library[102]);

        // // Retrieve using Book Title
        // Console.WriteLine(library["C# Basics"]);

        // // Observe behavior when title not found
        // Console.WriteLine(library["Python"]);
         Security security = new Security();
        security.Authenticate();

        // Create policies
        LifeInsurance life = new LifeInsurance
        {
            PolicyHolder = "Amit",
            PolicyNumber = 101,
            Premium = 5000
        };

        HealthInsurance health = new HealthInsurance
        {
            PolicyHolder = "Neha",
            PolicyNumber = 102,
            Premium = 8000
        };

        // Store policies
        PolicyDirectory directory = new PolicyDirectory();
        directory.AddPolicy(life);
        directory.AddPolicy(health);

        // Indexer usage
        Console.WriteLine(directory[0].PolicyHolder);        // Amit
        Console.WriteLine(directory["Neha"].PolicyNumber);   // 102

        // Runtime polymorphism
        Console.WriteLine("Life Premium: " + life.CalculatePremium());
        Console.WriteLine("Health Premium: " + health.CalculatePremium());

        // Method hiding demonstration
        life.ShowPolicy();                 // Derived reference
        InsurancePolicy baseRef = life;
        baseRef.ShowPolicy();              // Base reference
    }
}
}