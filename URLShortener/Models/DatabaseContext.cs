using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace URLShortener.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Database.sqlite" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Url>()
                .HasKey(u => new { u.Hash, LongUrl = u.OriginalUrl });
            
            builder.Entity<Url>()
                .HasIndex(u => new {u.Hash, LongUrl = u.OriginalUrl})
                .IsUnique();
        }
    }
    
}