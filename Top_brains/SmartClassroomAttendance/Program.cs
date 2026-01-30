using System;

public class Solution
{
    public bool IsAttendanceValid(
        int loginMinute,
        int totalMinutesPresent,
        bool biometricVerified
    )
    {
        if (loginMinute <= 10 && totalMinutesPresent >= 45 && biometricVerified)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

/*
▶️ Sample Execution (Platform Driven)

Input:
5, 50, true

Output:
true

Input:
15, 60, true

Output:
false
*/
