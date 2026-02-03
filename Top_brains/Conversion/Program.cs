<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> 200c4495cc9da882afb0c5e557db19a5a821c91d

public class Solution
{
    public static double ConvertFeetToCentimeters(int feet)
    {
        double centimeters = feet * 30.48;
        return Math.Round(centimeters, 2, MidpointRounding.AwayFromZero);
    }
}

/*
▶️ Sample Execution (Platform Driven)

Input:
feet = 5

Output:
152.40
*/
