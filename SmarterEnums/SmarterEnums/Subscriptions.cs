using Ardalis.SmartEnum;

namespace SmarterEnums;

public class Subscriptions : SmartEnum<Subscriptions>
{
    public static readonly Subscriptions Free = new("Free", 1, .0);
    public static readonly Subscriptions Premium = new("Premium", 2, .25);
    public static readonly Subscriptions Vip = new("VIP", 3, .5);
    
    // We can extend the default constructor of (string name, int value) to (string name, int value, double discount)
    public double Discount { get; }

    public Subscriptions(string name, int value, double discount) : base(name, value)
    {
        Discount = discount;
    }
}