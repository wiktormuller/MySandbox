using Ardalis.SmartEnum;

namespace SmarterEnums;

public abstract class Subscriptions : SmartEnum<Subscriptions>
{
    public static readonly Subscriptions Free = new FreeTier();
    public static readonly Subscriptions Premium = new PremiumTier();
    public static readonly Subscriptions Vip = new VipTier();
    
    // We can extend the default constructor of (string name, int value) to (string name, int value, double discount)
    // Or we can use inheritance to extend the Subscriptions that will be abstract
    public abstract double Discount { get; }

    private Subscriptions(string name, int value/*, double discount*/) : base(name, value)
    {
    }
    
    private sealed class FreeTier : Subscriptions
    {
        public FreeTier() : base("Free", 1)
        {
        }

        public override double Discount => .0;
    }
    
    private sealed class PremiumTier : Subscriptions
    {
        public PremiumTier() : base("Premium", 2)
        {
        }

        public override double Discount => .25;
    }
    
    private sealed class VipTier : Subscriptions
    {
        public VipTier() : base("VIP", 3)
        {
        }

        public override double Discount => .5;
    }
}