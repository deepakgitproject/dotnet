using System;

public class Solution
{
    public static string EvaluateExpression(string expression)
    {
        // 1. Check format: must be "a op b" with spaces
        if (string.IsNullOrWhiteSpace(expression))
            return "Error:InvalidExpression";

        string[] parts = expression.Split(' ');
        if (parts.Length != 3)
            return "Error:InvalidExpression";

        string aStr = parts[0];
        string op = parts[1];
        string bStr = parts[2];

        // 2. Validate operator
        if (op != "+" && op != "-" && op != "*" && op != "/")
            return "Error:UnknownOperator";

        // 3. Validate numbers
        if (!int.TryParse(aStr, out int a) || !int.TryParse(bStr, out int b))
            return "Error:InvalidNumber";

        // 4. Division by zero check
        if (op == "/" && b == 0)
            return "Error:DivideByZero";

        // 5. Perform calculation
        int result = 0;
        switch (op)
        {
            case "+": result = a + b; break;
            case "-": result = a - b; break;
            case "*": result = a * b; break;
            case "/": result = a / b; break;
        }

        return result.ToString();
    }

    public static void Main()
    {
        Console.Write("Enter expression (a op b): ");
        string expression = Console.ReadLine();

        string output = EvaluateExpression(expression);
        Console.WriteLine("Result: " + output);
    }
}

/*
▶️ Sample Execution

Input:
Enter expression (a op b): 10 / 2

Output:
Result: 5
*/
