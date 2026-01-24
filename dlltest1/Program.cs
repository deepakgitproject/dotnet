using System;

interface I1
{
    void m1();
    void m2();
}
class A : I1
{
    public void m1()
    {
        Console.WriteLine("This is method m1 from class A");
    }

    public void m2()
    {
        Console.WriteLine("This is method m2 from class A");
    }
}
class Program
{
    static void Main()
    {
        A a1 = new A();   // Step 2: Class A : A1

        a1.m1();
        a1.m2();
    }
}
