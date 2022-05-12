namespace Section_09_07
{
    internal class Communications : DeliveryBase
    {
        public override MailingAddress GetAddress(string name)
        {
            return new MailingAddress(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890",
                "me@example.com",
                true);
        }
    }
}