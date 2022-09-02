using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Services.ProductAPI.Migrations
{
    public partial class AddProductsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImagePath", "Name", "Price" },
                values: new object[] { new Guid("6f49d4a7-8103-49bc-a592-818f3a93ef87"), "Ноутбук", "Процессор и память: Процессор: Intel I5-1135G7 Количество ядер: Quad-Core Частота: 2.4 ГГц Оперативная память: 8 Гб Видеокарта: Intel Iris Xe Graphics Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,6 Толщина (мм): 16,9 Длина (мм): 309,9 Вес (г): 1200", "", "Ноутбук ASUS ExpertBook B5 13.3\"", 81990m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImagePath", "Name", "Price" },
                values: new object[] { new Guid("9df85a5e-6877-4601-bc12-0b3b94886c41"), "Ноутбук", "Процессор и память: Процессор: Intel i5-8250 Количество ядер: Quad-Core Частота: 3.4 ГГц Оперативная память: 8 Гб Видеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,9 Толщина (мм): 14,8 Длина (мм): 309,6 Вес (г): 1300", "", "Ноутбук Xiaomi Mi Notebook Air 13.3\"", 79900m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImagePath", "Name", "Price" },
                values: new object[] { new Guid("fc0ffabf-3cd2-45f9-af8b-3beb58c18f4e"), "Ноутбук", "Процессор и память: Количество ядер процессора: Dual-Core Частота: 3.0ГГц Оперативная память: 8 Гб Видеокарта: Intel UHD Graphics Дисплей: Диагональ экрана: 15.6 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 363.96 Толщина (мм): 19 Длина (мм): 249 Вес (г): 1780", "", "Ноутбук DELL Vostro 3500, 15.6\"", 35990m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f49d4a7-8103-49bc-a592-818f3a93ef87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9df85a5e-6877-4601-bc12-0b3b94886c41"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc0ffabf-3cd2-45f9-af8b-3beb58c18f4e"));
        }
    }
}
