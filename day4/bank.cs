class Student
{
    // Normal private fields
    private string name;
    private int age;
    private int marks;
    private string password;

    // PART A: Auto-Implemented Property
    public int StudentId { get; set; }

    // PART D: Normal Property - Name
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }

    // PART D: Normal Property - Age
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value > 0)
            {
                age = value;
            }
        }
    }

    // PART D: Normal Property - Marks
    public int Marks
    {
        get
        {
            return marks;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                marks = value;
            }
        }
    }

    // PART B: Read-Only Property
    public string Result
    {
        get
        {
            return marks >= 40 ? "Pass" : "Fail";
        }
    }

    // PART C: Write-Only Property
    public string Password
    {
        set
        {
            if (value.Length >= 6)
            {
                password = value;
            }
        }
    }
}