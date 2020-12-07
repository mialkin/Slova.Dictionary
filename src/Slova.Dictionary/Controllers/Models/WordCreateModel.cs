using System.ComponentModel.DataAnnotations;

namespace Slova.Dictionary.Controllers.Models
{
    public class WordCreateModel
    {
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