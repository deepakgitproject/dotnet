<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 200c4495cc9da882afb0c5e557db19a5a821c91d
using System.Collections.Generic;

// Student class to store student details
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    // Constructor to initialize values
    public Student(string name, int age, int marks)
    {
        Name = name;
        Age = age;
        Marks = marks;
    }

    // Override ToString to display student details
    public override string ToString()
    {
        return $"{Name} - Age: {Age}, Marks: {Marks}";
    }
}

// Custom comparer class to sort Student objects
class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        // First sort by Marks in DESCENDING order
        int markCompare = y.Marks.CompareTo(x.Marks);

        if (markCompare != 0)
            return markCompare;

        // If Marks are same, sort by Age in ASCENDING order
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        // Create list of students
        List<Student> students = new List<Student>()
        {
            new Student("Rahul", 20, 85),
            new Student("Amit", 19, 90),
            new Student("Neha", 18, 90),
            new Student("Priya", 21, 85),
            new Student("Karan", 22, 70)
        };

        // Sort students using custom comparer
        students.Sort(new StudentComparer());

        // Display sorted list
        Console.WriteLine("Sorted Student List:");
        foreach (var s in students)
        {
            Console.WriteLine(s);
        }
    }
}

/*
▶️ Sample Execution

Output:
Sorted Student List:
Neha - Age: 18, Marks: 90
Amit - Age: 19, Marks: 90
Rahul - Age: 20, Marks: 85
Priya - Age: 21, Marks: 85
Karan - Age: 22, Marks: 70
*/
