using System;
class Monthops
{
    public int add(ref int a,int b,out int c)

    {
        a = a+b;
        c=a;
        return a;
    }
    // public void add(int a,int b,int c)
    // {
    //     Console.WriteLine(a+b+c);
    // }
    // public double add(double a,double b)
    // {
    //     return a+b;
    // }
}