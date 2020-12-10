using System.ComponentModel.DataAnnotations;

namespace Slova.Dictionary.Repos.Filters
{
    public class ListWordsFilter
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LanguageId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; } = 100;
    }
}