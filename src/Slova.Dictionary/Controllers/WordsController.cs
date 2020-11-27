using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slova.Dictionary.Controllers.Filters;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Repos;

namespace Slova.Dictionary.Controllers
{
    public class WordsController : ControllerBase
    {
        private readonly IWordsRepository _wordsRepository;

        public WordsController(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllWordsFilter filter)
        {
            IEnumerable<Word> words = await _wordsRepository.GetAllAsync();
            
            return Ok(words);
        }
    }
}