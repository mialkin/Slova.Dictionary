using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Slova.Dictionary.IntegrationTests.ModelBindings
{
    public class WordsBindingsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public WordsBindingsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/words/list")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            HttpClient client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            //response.EnsureSuccessStatusCode(); // Status Code 200-299
            if (response.Content.Headers.ContentType != null)
            {
                Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        }
    }
}