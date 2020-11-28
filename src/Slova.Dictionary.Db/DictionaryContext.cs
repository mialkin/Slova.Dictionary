using Microsoft.EntityFrameworkCore;
using Slova.Dictionary.Db.Models;

namespace Slova.Dictionary.Db
{
    public class DictionaryContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }

        public DictionaryContext(DbContextOptions<DictionaryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasIndex(p => new { p.Name, p.LanguageId, p.UserId })
                .IsUnique();
        }
    }
}