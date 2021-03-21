using DecodeOficial.Domain.Entities;
using DecodeOficial.Domain.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DecodeOficial.Infrastructure.Data.Context
{
    public class DecodeContext : DbContext
    {
        public DecodeContext()
        {
        }

        public DecodeContext(DbContextOptions<DecodeContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Profession> Professions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("DecodeOficial.Domain.Entities.Person", b =>
            {
                b.HasOne("DecodeOficial.Domain.Entities.Profession", "Profession")
                    .WithMany()
                    .HasForeignKey("ProfessionId")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                b.Navigation("Profession");
            });
        }

        public override int SaveChanges()
        {
            //For each interaction with database, verifies if there is a property named "RegisterDate"
            //If exists and it's an inclusion, sets de curremt Datetime. If exsists and it's an update, doesn't update
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("RegisterDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegisterDate").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Modified)
                    entry.Property("RegisterDate").IsModified = false;
            }

            //For each interaction with database, verifies if there is a property named "Status"
            //If exists and it's an inclusion, set Status as Active
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("Status") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("Status").CurrentValue = Status.Active;
            }

            return base.SaveChanges();
        }
    }
}
