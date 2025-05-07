using GymJournal.Model;
using Microsoft.EntityFrameworkCore;

namespace GymJournal.Infrastructure.Database
{
    public class GymJournalContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        
        public GymJournalContext(DbContextOptions<GymJournalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //MOZDA TREBA HAS DEFAULT SCHEMA DA SE STAVI
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            ConfigureUser(modelBuilder);
        }

        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Person>(p => p.UserId);
        }
    }
}
