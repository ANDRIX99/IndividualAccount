using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IndividualAccount.Model;

namespace IndividualAccount.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Item>()
                .HasOne(i => i.CreatedBy)
                .WithMany()
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Item>()
                .HasOne(i => i.ModifiedBy)
                .WithMany()
                .HasForeignKey(i => i.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 

            builder.Entity<Item>()
                .HasOne(i => i.DeletedBy)
                .WithMany()
                .HasForeignKey(i => i.DeletedById)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 
        }
    }
}
