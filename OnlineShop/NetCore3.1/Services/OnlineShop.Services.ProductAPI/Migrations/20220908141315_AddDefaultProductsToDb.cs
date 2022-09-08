using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Services.ProductAPI.Migrations
{
    public partial class AddDefaultProductsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { new Guid("7e8b035a-bbbf-4f54-ae72-33a8f465ddef"), "Ноутбук", "Процессор и память: Процессор: Intel i5-8250 Количество ядер: Quad-Core Частота: 3.4 ГГц Оперативная память: 8 Гб Видеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,9 Толщина (мм): 14,8 Длина (мм): 309,6 Вес (г): 1300", "/img/xiaomi_mi_notebook_air_13_3.jpg", "Ноутбук Xiaomi Mi Notebook Air 13.3\"", 79900m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { new Guid("d3448cd5-84b7-4c3a-983a-a08cb711d30b"), "Ноутбук", "Процессор и память: Процессор: Intel I5-1135G7 Количество ядер: Quad-Core Частота: 2.4 ГГц Оперативная память: 8 Гб Видеокарта: Intel Iris Xe Graphics Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,6 Толщина (мм): 16,9 Длина (мм): 309,9 Вес (г): 1200", "img/asus_expertbook_B5.png", "Ноутбук ASUS ExpertBook B5 13.3\"", 81990m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImgUrl", "Name", "Price" },
                values: new object[] { new Guid("93bbd2b7-f83c-47b2-a7ea-535df37f0ba2"), "Ноутбук", "Процессор и память: Количество ядер процессора: Dual-Core Частота: 3.0ГГц Оперативная память: 8 Гб Видеокарта: Intel UHD Graphics Дисплей: Диагональ экрана: 15.6 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 363.96 Толщина (мм): 19 Длина (мм): 249 Вес (г): 1780", "/img/dell_vostro_3500_15_6.jpg", "Ноутбук DELL Vostro 3500, 15.6\"", 35990m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e8b035a-bbbf-4f54-ae72-33a8f465ddef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93bbd2b7-f83c-47b2-a7ea-535df37f0ba2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d3448cd5-84b7-4c3a-983a-a08cb711d30b"));
        }
    }
}
