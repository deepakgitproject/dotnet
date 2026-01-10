using System;
public class Chocolate
{
    public string Flavour;
    public int Quantity;
    public int PricePerUnit;
    public double TotalPrice;
    public double DiscountedPrice;

    public bool ValidateChocolateFlavour()
    {
        if(Flavour=="Dark" || Flavour=="Milk" || Flavour == "White")
        {
            return true;
        }
            return false;        
    }    
}
public class Program
{
public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
{
        chocolate.TotalPrice=chocolate.Quantity*chocolate.PricePerUnit;
        double DiscountPerc=0;
        if(chocolate.Flavour=="Dark")
            DiscountPerc=18;
        else if(chocolate.Flavour=="Milk")
            DiscountPerc=12;
        else if(chocolate.Flavour=="White")
            DiscountPerc=6;
        chocolate.DiscountedPrice=chocolate.TotalPrice-(chocolate.TotalPrice*DiscountPerc/100);
        return chocolate;
}
    static void Main()
{
    Chocolate chocolate = new Chocolate();

    Console.WriteLine("Enter the flavour");
    chocolate.Flavour = Console.ReadLine();
    Console.WriteLine("Enter the quantity");
    chocolate.Quantity = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the price per unit");
    chocolate.PricePerUnit = Convert.ToInt32(Console.ReadLine());
    if (!chocolate.ValidateChocolateFlavour())
    {
        Console.WriteLine("Invalid flavour");     
    }
    else
    {
        CalculateDiscountedPrice(chocolate);

        Console.WriteLine("Flavour : " + chocolate.Flavour);
        Console.WriteLine("Quantity : " + chocolate.Quantity);
        Console.WriteLine("Price Per Unit : " + chocolate.PricePerUnit);
        Console.WriteLine("Total Price : " + chocolate.TotalPrice);
        Console.WriteLine("Discounted Price : " + chocolate.DiscountedPrice);
    }
}

}
