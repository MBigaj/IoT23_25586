using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab3.Database
{
    public class AddressDb : DbContext
    {
        public AddressDb(DbContextOptions<AddressDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureAddressEntity(modelBuilder.Entity<Address>());
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureAddressEntity(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address");
            entity.Property(a => a.city).IsRequired();
            entity.Property(a => a.streetName).IsRequired();
        }

        public DbSet<Address> Address { get; set; }
    }
}