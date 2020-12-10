using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Slova.Dictionary.Controllers;
using Xunit;

namespace Slova.Dictionary.UnitTests.Controllers
{
    public class WordsControllerTests
    {
        [Fact]
        public async Task Create_ReturnsBadRequestWhenModelStateIsNotValid()
        {
            var controller = new WordsController(null, null);
            controller.ModelState.AddModelError("ModelStateError", "Model state is not valid.");

            IActionResult result = await controller.Create(null);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}