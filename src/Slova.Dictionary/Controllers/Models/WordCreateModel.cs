using System.ComponentModel.DataAnnotations;

namespace Slova.Dictionary.Controllers.Models
{
    public class WordCreateModel
    {
        public WordCreateModel(string name, string transcription, string translation, int gender, int languageId, int userId)
        {
            Name = name;
            Transcription = transcription;
            Translation = translation;
            Gender = gender;
            LanguageId = languageId;
            UserId = userId;
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string Transcription { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Translation { get; set; }
        
        [Range(0,2)]
        public int Gender { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int LanguageId { get; set; }
        
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}