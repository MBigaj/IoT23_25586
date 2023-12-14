using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab3.Database
{
    public class PersonDb : DbContext
    {
        public PersonDb(DbContextOptions<PersonDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePersonEntity(modelBuilder.Entity<Person>());
            ConfigureAddressEntity(modelBuilder.Entity<Address>());
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("Person");
            entity.Property(p => p.firstName).IsRequired();
            entity.Property(p => p.lastName).IsRequired();

            entity.HasOne(a => a.address)
            .WithMany(p => p.people)
            .HasForeignKey(fk => fk.id);
        }

        private void ConfigureAddressEntity(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address");
            entity.Property(a => a.city).IsRequired();
            entity.Property(a => a.streetName);

            entity.HasMany(p => p.people)
            .WithOne(a => a.address)
            .HasForeignKey(fk => fk.id);
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}