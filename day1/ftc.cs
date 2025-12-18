using System;

class Ftc
{
public static void calculate()
{
    double r = Convert.ToDouble(Console.ReadLine());
    double result = r*30.48;
    Console.WriteLine($"Here is the converted from feet {r} to cm = {result}");
}
}