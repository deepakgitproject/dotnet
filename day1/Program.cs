using System;
using System.Globalization;
using System.Net;
class ABC
{
    static void Main()
    {
        // Console.Write("Enter the value of r: ");
        // int[] arr = { 3, 2, 4, 5, 6 };
        // Bubble.Sort(arr);


        //sum of digits

        int a = 1234;
        int sum = 0;
        int rev = 0;
        while (a > 0)
        {
            int digit = a%10;
            a = a/10;
            sum += digit;
            rev +=digit;
            if (a != 0)
            {
                rev*=10;
            }
        }
        Console.WriteLine("Sum of digits: " + sum + "reverse of digit: "+rev);

        // Console.Write("Enter r: ");
        // string t =Console.ReadLine();
        // double r = Convert.ToDouble(t);
        // double area = 3.14 * r * r;
        // double result = Math.Pow(r, 2);
        // Console.WriteLine("r squared: " + result);
        // Console.WriteLine($"r squared: {result} and the area of circle is : {area}");
        // Console.WriteLine("Area of circle: " + area);

        // it calls the square fucntion
        // Square.Calculate();

        // it calls the feet to cm funtion 
        // Ftc.calculate();
        // from second to min
        // int s = Convert.ToInt32(Console.ReadLine());
        // Month.PrintMonth(s);
        // Tomin.tomin(s);
        // if(s%2 ==0)
        // {
        //     Console.WriteLine("even number");
        //     if(s == 10)
        //     {
        //         Console.WriteLine("it is 10");
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("odd number");
        // }
    }
}
