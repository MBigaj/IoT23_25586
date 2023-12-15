// using lab3.Database;

// namespace lab3.Services
// {
//     public class AddressService
//     {
//         private List<Address> addresses { get; } = new List<Address>();

//         public Address AddAddress(Address AddressData)
//         {
//             var address = new Address {
//                 city = AddressData.city,
//                 streetName = AddressData.streetName,
//             };

//             addresses.Add(address);
//             return address;
//         }

//         public Address Update(Address AddressData)
//         {
//             var Address = addresses.First(w => w.id == AddressData.id);
//             Address.city = AddressData.city;
//             Address.streetName = AddressData.streetName;

//             return Address;
//         }

//         public void Delete(int id)
//         {
//             var Address = addresses.First(w => w.id == id);
//             addresses.Remove(Address);
//         }

//         public Address FindById(int id)
//         {
//             return addresses.First(w => w.id == id);
//         }

//         public IEnumerable<Address> GetAddresses()
//         {
//             return addresses;
//         }
//     }
// }