using System.ComponentModel.DataAnnotations;

namespace AbpHelper.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}