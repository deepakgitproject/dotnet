using System;

public interface IProduct
{
    public string name {get;}
    public int id {get;}
    public decimal price {get;}
    void displaydetials();

}
class Electronics : IProduct
{
    public string name {get;}
    public int id {get;}
    public decimal price {get;}
    public string brand{get;}
    public string model{get;}
    public int WarrantyPeriod {get;} 
    public decimal PowerUsage {get;}
    // DateTime ManufacturingDate{get;}
    public Electronics(string name,int id,decimal price,string brand,string model,int WarrantyPeriod,decimal PowerUsage)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.brand=brand;
        this.model =model;
        this.WarrantyPeriod=WarrantyPeriod;
        this.PowerUsage = PowerUsage;

    }
    public void displaydetials()
    {
        Console.WriteLine($"your produt is {name} of brand {brand}");
    }
}

class Program
{
    static void Main()
    {
    //
    Console.Write("Product type (1=Electronics, 3=Exit): ");    
    // int a =Int.Parse(Console.ReadLine());
    while (true)
    {
        Console.Write("Enter your choice:");
        int a =int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("please enter your product details as: Name, id, price ");
                    string[] input = Console.ReadLine().Split();
                    string name = input[0];
                    int id = int.Parse(input[1]);
                    decimal price = decimal.Parse(input[2]);
                    // int idtype = input[3];
                    Console.WriteLine("Details for electronic Type please enter Brand,model,WarrantyPeriod (in months),PowerUsage (watts),");
                    // string[] input2 = Console.ReadLine().Split();

                    string brand= input[3];
                    string model= input[4];
                    int WarrantyPeriod= int.Parse(input[5]);
                    decimal PowerUsage = decimal.Parse(input[6]);
                    IProduct ec = new Electronics(name,id,price,brand,model,WarrantyPeriod,PowerUsage);
                    ec.displaydetials();
                    break;
                case 3:
                Environment.Exit(0);;
                break;

                
            }
    }
 // DateTime ManufacturingDate= input2[4];
        // Electronics ec = new Electronics(name,)
