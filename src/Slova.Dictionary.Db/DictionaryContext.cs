using Microsoft.EntityFrameworkCore;
using Slova.Dictionary.Db.Models;

namespace Slova.Dictionary.Db
{
    public class DictionaryContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}