using System;
class Game
{
    public static void Begin()
    {
        int total = 10;
        int Count=0;
        for(int i=0; i<total; i++)
        {
            if (i == 4)
            {
                Console.WriteLine($"Enemy {i} is invisible");
                continue;
            }
            Count+=1;
            Console.WriteLine($"Player killed enemy {i}");

        }
        Console.WriteLine($"{total-Count} Enemy left stay alert!!");
    }
}