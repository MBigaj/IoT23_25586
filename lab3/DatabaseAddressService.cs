// using lab3.Database;

// namespace lab3.Services
// {
//     public class DatabaseAddressService : AddressServiceInterface
//     {
//         private PersonDb db;

//         public DatabaseAddressService(PersonDb db)
//         {
//             this.db = db;
//         }

//         public Address AddAddress(Address address)
//         {
//             var entity = new Address
//             {
//                 city = address.city,
//                 streetName = address.streetName
//             };

//             this.db.Address.Add(entity);
//             this.db.SaveChanges();

//             address.id = entity.id;
//             return address;
//         }

//         public Address FindById(int id)
//         {
//             var address = this.db.Address.First(w => w.id == id);
//             return this.MapToDTO(address);
//         }

//         public IEnumerable<Address> GetAddresses()
//         {
//             var addressList = this.db.Address.Select(s => new Address
//             {
//                 id = s.id,
//                 city = s.city,
//                 streetName = s.streetName
//             });

//             return addressList;
//         }

//         public Address MapToDTO(Address entity)
//         {
//             return new Address
//             {
//                 id = entity.id,
//                 city = entity.city,
//                 streetName = entity.streetName
//             };
//         }
//     }
// }