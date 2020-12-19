using System.Collections.Generic;
using System.Threading.Tasks;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Repos.Filters;
using Slova.Dictionary.Repos.Infrastructure;

namespace Slova.Dictionary.Repos.Interfaces
{
    public interface IWordsRepository : IRepository<Word>
    {
        Task<List<Word>> ListAsync(ListWordsFilter filter);
    }
}