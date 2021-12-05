using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfoViewModel
    {
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Имя не может быть меньше двух букв")]
        [RegularExpression(@"[а-яА-Я-]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания имени")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия не может быть меньше двух букв")]
        [RegularExpression(@"[а-яА-Я-]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания фамилии")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Название города не может быть меньше двух букв")]
        [RegularExpression(@"[а-яА-Я-]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания города")]
        public string City { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [RegularExpression(@"[1-6]{1}[0-9]{5}$", ErrorMessage = "Введите корректный почтовый индекс")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Название улицы, номер дома, корпус, номер квартиры не может быть меньше 10 символов")]
        [RegularExpression(@"[а-яА-Я-0-9,/.\s]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания адреса. Допустимые символы: , . /")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [RegularExpression(@"\+7\s[0-9]{3}\s[0-9]{3}\-[0-9]{2}\-[0-9]{2}$", ErrorMessage = "Введите номер телефона в формате: +7 XXX XXX-XX-XX")]
        public string Phone { get; set; }

        [RegularExpression(@"[а-яА-Я-0-9,.!%:?();\s]+$", ErrorMessage = "Пожалуйста, используйте кириллицу для указания комментария. Допустимые символы: . , : ; % () ? !")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Комментарий не может быть меньше 10 символов")]
        public string Comments { get; set; }
    }
}