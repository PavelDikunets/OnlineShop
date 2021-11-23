using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserAccount
    {
        public UserAccount()
        {
            Id = InstanceCounter;
            InstanceCounter += 1;
        }

        private static int InstanceCounter = 0;
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [EmailAddress(ErrorMessage = "E-mail указан неверно")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль не может быть меньше 6 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Имя не может быть меньше двух букв")]
        [RegularExpression(@"[а-яА-Я-]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания имени")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия не может быть меньше двух букв")]
        [RegularExpression(@"[а-яА-Я-]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания фамилии")]
        public string LastName { get; set; }

        [RegularExpression(@"\+7\s[0-9]{3}\s[0-9]{3}\-[0-9]{2}\-[0-9]{2}$", ErrorMessage = "Введите номер телефона в формате: +7 XXX XXX-XX-XX")]
        public string Phone { get; set; }
    }
}
