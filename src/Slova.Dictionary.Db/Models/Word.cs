using System;
using System.ComponentModel.DataAnnotations;

namespace Slova.Dictionary.Db.Models
{
    public class Word
    {
        public Word(int languageId, int userId, string name, string translation)
        {
            LanguageId = languageId;
            UserId = userId;
            Name = name;
            Translation = translation;
        }

        public long WordId { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string? Transcription { get; set; }

        [Required]
        public string Translation { get; set; }
        
        public int Gender { get; set; }
        
        [Required]
        public DateTime CreationDate { get; set; }

        public int LanguageId { get; set; }
        public Language? Language { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}