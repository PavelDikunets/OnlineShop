using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddProductImagePath_1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ec6df99-ee94-42e9-8848-cb5d50866eb1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("24977ba1-1c45-4fb6-8dc1-a623ea81b86b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e957739e-c5bf-487b-84c8-188a8269fb32"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[] { new Guid("d33bd802-9f3e-4e58-8e11-bab67d0716c8"), 79900m, "Процессор и память:\nПроцессор: Intel i5-8250\nКоличество ядер: Quad-Core\nЧастота: 3.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,9\nТолщина (мм): 14,8\nДлина (мм): 309,6\nВес (г): 1300", "/img/xiaomi_mi_ notebook_air_13_3.jpg", "Ноутбук Xiaomi Mi Notebook Air 13.3\"" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[] { new Guid("17863298-63a0-4469-b83d-cd973700f6b6"), 81990m, "Процессор и память:\nПроцессор: Intel I5-1135G7\nКоличество ядер: Quad-Core\nЧастота: 2.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel Iris Xe Graphics\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,6\nТолщина (мм): 16,9\nДлина (мм): 309,9\nВес (г): 1200", "/img/asus_expertbook_B5.png", "Ноутбук ASUS ExpertBook B5 13.3\"" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[] { new Guid("fb012b0b-af54-4a46-b33a-2d31617c1e7a"), 35990m, "Процессор и память:\nКоличество ядер процессора: Dual-Core\nЧастота: 3.0ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel UHD Graphics\n\nДисплей:\nДиагональ экрана: 15.6\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 363.96\nТолщина (мм): 19\nДлина (мм): 249\nВес (г): 1780", "/img/dell_vostro_3500_15_6.jpg", "Ноутбук DELL Vostro 3500, 15.6\"" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17863298-63a0-4469-b83d-cd973700f6b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d33bd802-9f3e-4e58-8e11-bab67d0716c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb012b0b-af54-4a46-b33a-2d31617c1e7a"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("24977ba1-1c45-4fb6-8dc1-a623ea81b86b"), 79900m, "Процессор и память:\nПроцессор: Intel i5-8250\nКоличество ядер: Quad-Core\nЧастота: 3.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,9\nТолщина (мм): 14,8\nДлина (мм): 309,6\nВес (г): 1300", "Ноутбук Xiaomi Mi Notebook Air 13.3\"" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("e957739e-c5bf-487b-84c8-188a8269fb32"), 81990m, "Процессор и память:\nПроцессор: Intel I5-1135G7\nКоличество ядер: Quad-Core\nЧастота: 2.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel Iris Xe Graphics\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,6\nТолщина (мм): 16,9\nДлина (мм): 309,9\nВес (г): 1200", "Ноутбук ASUS ExpertBook B5 13.3\"" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("0ec6df99-ee94-42e9-8848-cb5d50866eb1"), 35990m, "Процессор и память:\nКоличество ядер процессора: Dual-Core\nЧастота: 3.0ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel UHD Graphics\n\nДисплей:\nДиагональ экрана: 15.6\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 363.96\nТолщина (мм): 19\nДлина (мм): 249\nВес (г): 1780", "Ноутбук DELL Vostro 3500, 15.6\"" });
        }
    }
}
