using System;
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
    [ApiController]
    [Route("[controller]")]
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
        [Route("list")]
        public async Task<IActionResult> List(ListWordsFilter filter)
        {
            IEnumerable<Word> words = await _wordsRepository.ListAsync(filter);
            return Ok(words);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] WordCreateModel model)
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
            await _wordsRepository.SaveChangesAsync();

            return Ok();
        }
    }
}