using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lab3.Database
{
    public class AddressDbFactory : IDesignTimeDbContextFactory<AddressDb>
    {
        public AddressDb CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AddressDb>();
            builder.UseSqlServer("Server=tcp:iot-server-cdv.database.windows.net,1433;Initial Catalog=iot_database;Persist Security Info=False;User ID=nick;Password=Superdatabase1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new AddressDb(builder.Options);
        }
    }
}