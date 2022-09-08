using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.ProductAPI.Models;
using System;

namespace OnlineShop.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ноутбук Xiaomi Mi Notebook Air 13.3\"",
                    Price = 79900,
                    Description = "Процессор и память: Процессор: Intel i5-8250 Количество ядер: Quad-Core Частота: 3.4 ГГц Оперативная память: 8 Гб Видеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,9 Толщина (мм): 14,8 Длина (мм): 309,6 Вес (г): 1300",
                    ImgUrl = "/img/xiaomi_mi_notebook_air_13_3.jpg",
                    CategoryName = "Ноутбук"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ноутбук ASUS ExpertBook B5 13.3\"",
                    Price = 81990,
                    Description = "Процессор и память: Процессор: Intel I5-1135G7 Количество ядер: Quad-Core Частота: 2.4 ГГц Оперативная память: 8 Гб Видеокарта: Intel Iris Xe Graphics Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,6 Толщина (мм): 16,9 Длина (мм): 309,9 Вес (г): 1200",
                    ImgUrl = "img/asus_expertbook_B5.png",
                    CategoryName = "Ноутбук"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ноутбук DELL Vostro 3500, 15.6\"",
                    Price = 35990,
                    Description = "Процессор и память: Количество ядер процессора: Dual-Core Частота: 3.0ГГц Оперативная память: 8 Гб Видеокарта: Intel UHD Graphics Дисплей: Диагональ экрана: 15.6 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 363.96 Толщина (мм): 19 Длина (мм): 249 Вес (г): 1780",
                    ImgUrl = "/img/dell_vostro_3500_15_6.jpg",
                    CategoryName = "Ноутбук"
                }
                );
        }
    }
}
