namespace Section_09_02
{
    internal class Program
    {
        // doesn't work at this level
        // var address = new Address();

        // this still works
        private Address addressOld = new();

        // new target typed field
        private Address addressNew = new();

        private static void Main()
        {
            // these still work
            var addressLocalVar = new Address();
            var addressLocalOld = new Address();

            // new target typed local variable
            Address addressLocalNew = new();

            // target typed with object ini
            Address addressObjectInit = new()
            {
                Street = "123 4th St.",
                City = "My City",
                State = "ZZ",
                Zip = "55555-3333"
            };

            // target typed with ctor init
            Address addressCtorInit = new(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890");
        }
    }
}