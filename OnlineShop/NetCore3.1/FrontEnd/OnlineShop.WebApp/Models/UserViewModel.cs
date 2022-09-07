using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Логин не может быть меньше 4 символов")]
        [RegularExpression(@"[a-z,A-Z,0-9]+$", ErrorMessage = "Логин может состоять только из цифр и букв английской раскладки")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "E-mail указан неверно")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль не может быть меньше 6 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"\+7\s[0-9]{3}\s[0-9]{3}\-[0-9]{2}\-[0-9]{2}$", ErrorMessage = "Введите номер телефона в формате: +7 XXX XXX-XX-XX")]
        public string PhoneNumber { get; set; }
    }
}
