using System;
using System.Collections.Generic;
public delegate bool IsEligibleforScholarship(Student std);

public class Student
{
    public int Rollno{get; set;}
    public string Name{get; set;}
    public int Marks{get; set;}
    public char SportsGrade{get; set;}

      public static string GetEligibleStudents(List<Student> studentsList,IsEligibleforScholarship isEligible)
    {
        List<string> eligibleNames = new List<string>();
        foreach (Student std in studentsList)
        {
            if (isEligible(std))
            {
                eligibleNames.Add(std.Name);
            }
        }

        return string.Join(",", eligibleNames);
    }
}

class Program
{
    public static bool ScholarshipEligibility(Student std)
    {
        return std.Marks > 80 && std.SportsGrade == 'A';

    }
     static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Rollno = 1, Name = "Ramu", Marks = 85, SportsGrade = 'A' },
            new Student {Rollno = 2, Name = "dosa",Marks = 99, SportsGrade = 'B'},
            new Student { Rollno = 3, Name = "Amit", Marks = 90, SportsGrade = 'B' },
            new Student { Rollno = 4, Name = "Neha", Marks = 88, SportsGrade = 'A' }
        };

        IsEligibleforScholarship ec = ScholarshipEligibility;

        string result = Student.GetEligibleStudents(students, ec);
        Console.WriteLine(result);
        }
}