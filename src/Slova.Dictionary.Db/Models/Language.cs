using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Slova.Dictionary.Db.Models
{
    public class Language
    {
        public Language(string name)
        {
            Name = name;
        }

        public int LanguageId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public List<Word> Words { get; } = new List<Word>();
    }
}