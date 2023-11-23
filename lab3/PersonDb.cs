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
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("Person");
            entity.Property(p => p.firstName).IsRequired();
            entity.Property(p => p.lastName).IsRequired();
        }

        public DbSet<Person> Person { get; set; }
    }
}