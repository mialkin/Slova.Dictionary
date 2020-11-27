using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slova.Dictionary.Controllers.Filters;
using Slova.Dictionary.Controllers.Models;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Infrastructure;
using Slova.Dictionary.Repos;

namespace Slova.Dictionary.Controllers
{
    public class WordsController : ControllerBase
    {
        private readonly IWordsRepository _wordsRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public WordsController(IWordsRepository wordsRepository, IDateTimeProvider dateTimeProvider)
        {
            _wordsRepository = wordsRepository;
            _dateTimeProvider = dateTimeProvider;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllWordsFilter filter)
        {
            IEnumerable<Word> words = await _wordsRepository.GetAllAsync();
            
            return Ok(words);
        }

        [HttpPost]
        public async Task Create(WordCreateModel model)
        {
            var word = new Word
            {
                Name = model.Name,
                Transcription = model.Transcription,
                Translation = model.Translation,
                Gender = model.Gender,
                LanguageId = model.LanguageId,
                CreationDate = _dateTimeProvider.UtcNow,
            };
            await _wordsRepository.AddAsync(word);
        }
    }
}