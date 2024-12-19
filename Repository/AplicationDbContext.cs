using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }


        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.IdPerson);
                entity.Property(p => p.Name);
                entity.Property(p => p.LastName);
                entity.Property(p => p.DocumentNumber); 
                entity.Property(p => p.Birthdate);
            });

           
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.IdAddress);
                entity.Property(a => a.Description);

                
                entity.HasOne<Person>()
                    .WithMany() 
                    .HasForeignKey(a => a.IdPerson)
                    .OnDelete(DeleteBehavior.Cascade);
            });

           
            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail);
                entity.Property(e => e.EmailAddres);

                
                entity.HasOne<Person>()
                    .WithMany() 
                    .HasForeignKey(e => e.IdPerson) 
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(p => p.IdPhone);
                entity.Property(p => p.PhoneNumber);

               
                entity.HasOne<Person>()
                    .WithMany() 
                    .HasForeignKey(p => p.IdPerson)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
