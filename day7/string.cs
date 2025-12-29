using System;
using System.Collections.Generic;

class Sus
{
    public string con(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length < 6)
            return string.Empty;

        foreach (char c in s)
        {
            if (!char.IsLetter(c))
                return string.Empty;
        }

        s = s.ToLower();
        var filt = new List<char>();

        foreach (char c in s)
        {
            if ((int)c % 2 != 0)
                filt.Add(c);
        }

        filt.Reverse();

        string result = "";
        for (int i = 0; i < filt.Count; i++)
        {
            if (i % 2 == 0)
                result += char.ToUpper(filt[i]);
            else
                result += filt[i];
        }

        return result;
    }
}


