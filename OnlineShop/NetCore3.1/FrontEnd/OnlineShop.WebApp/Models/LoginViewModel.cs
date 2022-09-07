using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Логин не может быть меньше 4 символов")]
        [RegularExpression(@"[a-z,A-Z,0-9]+$", ErrorMessage = "Логин может состоять только из цифр и букв английской раскладки")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль не может быть меньше 6 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
