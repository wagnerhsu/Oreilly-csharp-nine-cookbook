using System.Collections.Generic;

namespace Section_09_09
{
    public class AddressService
    {
        public IEnumerable<Address[]> GetAddresses(int perPage)
        {
            var addresses = GetAddresses();

            for (int i = 0, j = i + perPage;
                 i < addresses.Length;
                 i += perPage, j += perPage)
                yield return addresses[i..j];
        }

        private Address[] GetAddresses()
        {
            var count = 15;
            List<Address> addresses = new();

            for (var i = 0; i < count; i++)
            {
                var streetSuffix =
                    i switch
                    {
                        0 => "st",
                        1 => "nd",
                        2 => "rd",
                        _ => "th"
                    };

                addresses.Add(
                    new Address(
                        $"{i + 100} {i + 1}{streetSuffix} St.",
                        "My Place",
                        "ZZ",
                        "12345-7890"));
            }

            return addresses.ToArray();
        }
    }
}