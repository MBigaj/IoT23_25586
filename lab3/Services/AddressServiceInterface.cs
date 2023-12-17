using lab3.Database;

namespace lab3
{
    public interface AddressServiceInterface
    {
        Address FindById(int id);
        IEnumerable<Address> GetAddresses();
        Address AddAddress(Address address);
    }
}