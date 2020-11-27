using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Slova.Dictionary.Controllers.Filters;

namespace Slova.Dictionary.Controllers
{
    public class WordsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(GetAllWordsFilter filter)
        {
            return Ok(new List<string>{"one", "deux", "trois"});
        }
    }
}