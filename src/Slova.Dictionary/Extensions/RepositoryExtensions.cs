using Microsoft.Extensions.DependencyInjection;
using Slova.Dictionary.Repos.Interfaces;
using Slova.Dictionary.Repos.Repositories;

namespace Slova.Dictionary.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IWordsRepository, WordsRepository>();

        }
    }
}