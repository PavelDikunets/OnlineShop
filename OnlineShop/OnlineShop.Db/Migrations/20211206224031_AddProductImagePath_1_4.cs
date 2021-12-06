using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddProductImagePath_1_4 : Migration
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("7367554d-d0c1-4a4b-aafd-07557c1c43a1"), 79900m, "Процессор и память:\nПроцессор: Intel i5-8250\nКоличество ядер: Quad-Core\nЧастота: 3.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,9\nТолщина (мм): 14,8\nДлина (мм): 309,6\nВес (г): 1300", "Ноутбук Xiaomi Mi Notebook Air 13.3\"" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("eee6ae75-0426-4b7e-b135-812b9c50e239"), 81990m, "Процессор и память:\nПроцессор: Intel I5-1135G7\nКоличество ядер: Quad-Core\nЧастота: 2.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel Iris Xe Graphics\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,6\nТолщина (мм): 16,9\nДлина (мм): 309,9\nВес (г): 1200", "Ноутбук ASUS ExpertBook B5 13.3\"" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("a789ecb8-5428-4eb8-bc17-c6ef94838c3c"), 35990m, "Процессор и память:\nКоличество ядер процессора: Dual-Core\nЧастота: 3.0ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel UHD Graphics\n\nДисплей:\nДиагональ экрана: 15.6\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 363.96\nТолщина (мм): 19\nДлина (мм): 249\nВес (г): 1780", "Ноутбук DELL Vostro 3500, 15.6\"" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7367554d-d0c1-4a4b-aafd-07557c1c43a1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a789ecb8-5428-4eb8-bc17-c6ef94838c3c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eee6ae75-0426-4b7e-b135-812b9c50e239"));

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
