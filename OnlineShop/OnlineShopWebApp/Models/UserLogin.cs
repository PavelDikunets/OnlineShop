using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Заполните поле")]
        [EmailAddress(ErrorMessage = "E-mail указан неверно")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль не может быть меньше 6 символов")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
