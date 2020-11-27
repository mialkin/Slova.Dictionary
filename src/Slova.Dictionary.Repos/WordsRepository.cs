using System;
using Microsoft.EntityFrameworkCore;
using Slova.Dictionary.Db.Models;

namespace Slova.Dictionary.Repos
{
    public class WordsRepository : BaseRepository<Word>, IWordsRepository
    {
        public WordsRepository(DbContext context) : base(context)
        {
        }
    }
}