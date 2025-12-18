using System;

class Month
{
    public static void PrintMonth(int a)
    {
        switch (a)
        {
            case 1:
                Console.WriteLine("January");
                break;

            default:
                Console.WriteLine("Other month");
                break;
        }
    }
}
