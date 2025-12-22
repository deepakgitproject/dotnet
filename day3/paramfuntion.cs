using System;
class Params
{
    public static void sum(params int[] num)
    {
        int total = 0;
        foreach(int a in num)
        {
            total +=a;
        }
        Console.Write(total);
    }
}