using System.ComponentModel.DataAnnotations;

namespace AbpBookApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}