using System;
using System.Collections.Generic;

// 1. Security Module
sealed class Security
{
    public void Authenticate()
    {
        Console.WriteLine("User authenticated successfully");
    }
}

// 2. Base Insurance Policy
abstract class InsurancePolicy
{
    public int PolicyNumber { get; init; }
    public string PolicyHolder { get; set; }

    private double premium;
    public double Premium
    {
        get => premium;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Premium must be greater than zero");
            premium = value;
        }
    }

    public virtual double CalculatePremium()
    {
        return Premium;
    }

    public void ShowPolicy()
    {
        Console.WriteLine("Insurance Policy");
    }
}

// 3a. Life Insurance
class LifeInsurance : InsurancePolicy
{
    private const double LifeCharge = 500;

    public override double CalculatePremium()
    {
        return Premium + LifeCharge;
    }

    // Method Hiding
    public new void ShowPolicy()
    {
        Console.WriteLine("Life Insurance Policy");
    }
}

// 3b. Health Insurance
class HealthInsurance : InsurancePolicy
{
    public sealed override double CalculatePremium()
    {
        return Premium;
    }
}

// 4. Policy Directory with Indexers
class PolicyDirectory
{
    private List<InsurancePolicy> policies = new List<InsurancePolicy>();

    public void AddPolicy(InsurancePolicy policy)
    {
        policies.Add(policy);
    }

    // Indexer by index
    public InsurancePolicy this[int index]
    {
        get { return policies[index]; }
    }

    // Indexer by policy holder name
    public InsurancePolicy this[string name]
    {
        get
        {
            foreach (var policy in policies)
            {
                if (policy.PolicyHolder == name)
                    return policy;
            }
            return null;
        }
    }
}