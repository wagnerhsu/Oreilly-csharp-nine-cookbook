namespace Section_09_07
{
    internal class Shipping : DeliveryBase
    {
        public override ShippingAddress GetAddress(string name)
        {
            return new ShippingAddress(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890",
                "Ring Doorbell");
        }
    }
}