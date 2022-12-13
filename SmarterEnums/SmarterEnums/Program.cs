using SmarterEnums;

var freeSubscription = Subscriptions.Free;
var anotherFreeSubscription = Subscriptions.Free;

// The equals happens on value property
Console.WriteLine(freeSubscription == anotherFreeSubscription);

// Converting string name to 'enum'
var vipFromString = Subscriptions.FromName("VIP");
var vipSubscription = Subscriptions.Vip;
Console.WriteLine(vipSubscription == vipFromString);

// Converting int value to 'enum'
var premiumFromInt = Subscriptions.FromValue(2);
var premiumSubscription = Subscriptions.Premium;
Console.WriteLine(premiumFromInt == premiumSubscription);

// Extended default 'enum'
Console.WriteLine($"Discount was {premiumSubscription.Discount}");