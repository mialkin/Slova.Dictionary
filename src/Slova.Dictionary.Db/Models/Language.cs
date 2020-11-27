using System.Collections.Generic;

namespace Slova.Dictionary.Db.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public List<Word> Words { get; } = new List<Word>();
    }
}