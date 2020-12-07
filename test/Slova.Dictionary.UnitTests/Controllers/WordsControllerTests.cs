using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Slova.Dictionary.Controllers;
using Slova.Dictionary.Controllers.Models;
using Slova.Dictionary.Db.Models;
using Slova.Dictionary.Repos;
using Slova.Dictionary.Repos.Filters;
using Xunit;

namespace Slova.Dictionary.UnitTests.Controllers
{
    public class WordsControllerTests
    {
        [Fact]
        public async Task List_ThrowsWhenFilterIsNull()
        {
            // Arrange
            var wordsRepository = new Mock<IWordsRepository>();
            wordsRepository
                .Setup(x => x.ListAsync(It.IsAny<ListWordsFilter>()))
                .ReturnsAsync(It.IsAny<List<Word>>());

            // Act
            var controller = new WordsController(wordsRepository.Object, dateTimeProvider: null);
            IActionResult result = await controller.List(null);

            // Assert
            OkObjectResult okObjectResult =
                Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task List_ReturnsOkWhenFilterModelIsValid()
        {
            var wordsRepository = new Mock<IWordsRepository>();
            wordsRepository
                .Setup(x => x.ListAsync(It.IsAny<ListWordsFilter>()))
                .ReturnsAsync(It.IsAny<List<Word>>());

            var controller = new WordsController(wordsRepository.Object, dateTimeProvider: null);

            var filter = new ListWordsFilter
            {
                LanguageId = 1,
                UserId = 1
            };

            IActionResult result = await controller.List(filter);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsOkWhenCreateModelIsValid()
        {
            var wordsRepository = new Mock<IWordsRepository>();
            wordsRepository
                .Setup(x => x.AddAsync(It.IsAny<Word>()));

            var controller = new WordsController(wordsRepository.Object, dateTimeProvider: null);

            var model = new WordCreateModel
            {
                LanguageId = 1
            };

            IActionResult result = await controller.Create(model);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsBadRequestWhenModelStateIsNotValid()
        {
            var wordsRepository = new Mock<IWordsRepository>();
            var controller = new WordsController(null, dateTimeProvider: null);
            controller.ModelState.AddModelError("ErrorKey", "Error message.");

            IActionResult result = await controller.Create(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}