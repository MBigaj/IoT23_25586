using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lab3.Database
{
    public class PersonDbFactory : IDesignTimeDbContextFactory<PersonDb>
    {
        public PersonDb CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PersonDb>();
            builder.UseSqlServer("Server=tcp:lab3-iot.database.windows.net,1433;Initial Catalog=iot-database;Persist Security Info=False;User ID=nick;Password=Superdatabase1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new PersonDb(builder.Options);
        }
    }
}