using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Название роли должно быть не меньше 5 и не больше 20 символов")]
        [RegularExpression(@"[a-zA-Z-]+$", ErrorMessage = "Название роли только на английской раскладке, без символов и цифр")]
        public string Name { get; set; }
    }
}