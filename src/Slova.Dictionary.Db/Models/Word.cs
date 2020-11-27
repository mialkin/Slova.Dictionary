using System;
using System.ComponentModel.DataAnnotations;

namespace Slova.Dictionary.Db.Models
{
    public class Word
    {
        public int WordId { get; set; }
        
        [Required] 
        public string Name { get; set; }
        public string Transcription { get; set; }

        [Required] 
        public string Translation { get; set; }
        public int? Gender { get; set; }
        
        [Required] 
        public DateTime CreationDate { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}