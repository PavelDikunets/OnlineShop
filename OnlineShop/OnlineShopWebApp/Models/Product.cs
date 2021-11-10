using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int InstanceCounter = 0;
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Наименование продукта не может быть меньше 15 символов")]
        [RegularExpression(@"[^`~!@#$%^&*()_=+<>|\/?;:№]+$", ErrorMessage = "Пожалуйста, для указания наименования продукта не используйте следующие символы: ` ~ ! @ # $ % ^ & * ( ) _ = + | < > / ? ; : № ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [Range(35000, 150000, ErrorMessage = "Диапозон цены: минимум 35000, максимум 150000")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(400, MinimumLength = 50, ErrorMessage = "Описание продукта не может быть меньше 50 символов")]
        [RegularExpression(@"[^`~!@#$%^&*_=+<>|\/?;№]+$", ErrorMessage = "Пожалуйста, для указания описания продукта не используйте следующие символы: ` ~ ! @ # $ % ^ & * _ = + | < > / ? ; № ")]
        public string Description { get; set; }
        public Product()
        {
            Id = InstanceCounter;
            InstanceCounter += 1;
        }
    }
}