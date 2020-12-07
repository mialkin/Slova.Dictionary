using System.Collections.Generic;
using System.Threading.Tasks;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Repos.Filters;

namespace Slova.Dictionary.Repos
{
    public interface IWordsRepository : IRepository<Word>
    {
        Task<List<Word>> ListAsync(ListWordsFilter filter);
    }
}