using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Название роли должно быть не меньше 5 и не больше 20 букв")]
        [RegularExpression(@"[а-яА-Яa-zA-Z-]+$", ErrorMessage = "Название роли без символов и цифр")]
        public string Name { get; set; }
    }
}