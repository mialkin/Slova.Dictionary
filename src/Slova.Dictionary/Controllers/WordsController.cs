using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slova.Dictionary.Controllers.Models;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Infrastructure;
using Slova.Dictionary.Repos;
using Slova.Dictionary.Repos.Filters;

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
        public async Task<IActionResult> List(ListWordsFilter filter)
        {
            IEnumerable<Word> words = await _wordsRepository.List(filter);

            return Ok(words);
        }

        [HttpPost]
        public Task Create(WordCreateModel model)
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

            return _wordsRepository.AddAsync(word);
        }
    }
}