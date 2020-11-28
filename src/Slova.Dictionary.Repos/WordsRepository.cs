using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slova.Dictionary.Db;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Repos.Filters;

namespace Slova.Dictionary.Repos
{
    public class WordsRepository : BaseRepository<Word>, IWordsRepository
    {
        public WordsRepository(DictionaryContext context) : base(context)
        {
        }

        public async Task<IList<Word>> List(ListWordsFilter filter)
        {
            IQueryable<Word> words = Context.Set<Word>().AsQueryable();

            if (filter.LanguageId > 0)
                words = words.Where(x => x.LanguageId == filter.LanguageId);

            if (filter.Skip > 0)
                words = words.Skip(filter.Skip);

            if (filter.Take > 0)
                words = words.Take(filter.Take);

            return await words.ToListAsync();
        }
    }
}