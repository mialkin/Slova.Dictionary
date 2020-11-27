using System;

namespace Slova.Dictionary.Db.Models
{
    public class Word
    {
        public int WordId { get; set; }
        public string Name { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public int? Gender { get; set; }
        public DateTime CreationDate { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}