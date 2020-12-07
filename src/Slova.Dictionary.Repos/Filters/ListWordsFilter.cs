using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Slova.Dictionary.Db.Models;

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

        public Dictionary<string, ListSortDirection> Sort { get; set; } = new Dictionary<string, ListSortDirection>
        {
            [nameof(Word.CreationDate)] = ListSortDirection.Descending
        };
    }
}