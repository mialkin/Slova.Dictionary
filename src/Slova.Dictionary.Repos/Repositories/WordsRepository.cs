using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slova.Dictionary.Db;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Repos.Filters;
using Slova.Dictionary.Repos.Infrastructure;
using Slova.Dictionary.Repos.Interfaces;

namespace Slova.Dictionary.Repos.Repositories
{
    public class WordsRepository : BaseRepository<Word>, IWordsRepository
    {
        public WordsRepository(DictionaryContext context) : base(context)
        {
        }

        public Task<List<Word>> ListAsync(ListWordsFilter filter)
        {
            IQueryable<Word> words = Context.Set<Word>();

            words = words
                .Where(x => x.UserId == filter.UserId && x.LanguageId == filter.LanguageId)
                .OrderByDescending(x => x.CreationDate)
                .Skip(filter.Skip)
                .Take(filter.Take);

            return words.ToListAsync();
        }
    }
}