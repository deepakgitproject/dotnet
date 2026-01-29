using System;
using System.Collections.Generic;
class Student
{
    public string Name{get; set;}
    public int Age{get; set;}
    public int Marks{get; set;}
    public Student(string name,int age,int marks)
    {
        Name=name;
        Age=age;
        Marks=marks;
    }
    public override string ToString()
    {
        return $"{Name} - Age: {Age}, Marks: {Marks}";
    }

}
class StudentComparer : IComparer<Student>
{
     public int Compare(Student x, Student y)
    {
        int markCompare = y.Marks.CompareTo(x.Marks);

        if (markCompare != 0)
            return markCompare;
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Rahul", 20, 85),
            new Student("Amit", 19, 90),
            new Student("Neha", 18, 90),
            new Student("Priya", 21, 85),
            new Student("Karan", 22, 70)
        };
        students.Sort(new StudentComparer());
        Console.WriteLine("Sorted Student List:");
        foreach (var s in students)
        {
            Console.WriteLine(s);
        }
    }
}