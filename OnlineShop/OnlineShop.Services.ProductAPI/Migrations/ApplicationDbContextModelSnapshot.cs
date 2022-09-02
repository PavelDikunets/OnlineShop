﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Services.ProductAPI.DbContexts;

#nullable disable

namespace OnlineShop.Services.ProductAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineShop.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9df85a5e-6877-4601-bc12-0b3b94886c41"),
                            Category = "Ноутбук",
                            Description = "Процессор и память: Процессор: Intel i5-8250 Количество ядер: Quad-Core Частота: 3.4 ГГц Оперативная память: 8 Гб Видеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,9 Толщина (мм): 14,8 Длина (мм): 309,6 Вес (г): 1300",
                            ImagePath = "",
                            Name = "Ноутбук Xiaomi Mi Notebook Air 13.3\"",
                            Price = 79900m
                        },
                        new
                        {
                            Id = new Guid("6f49d4a7-8103-49bc-a592-818f3a93ef87"),
                            Category = "Ноутбук",
                            Description = "Процессор и память: Процессор: Intel I5-1135G7 Количество ядер: Quad-Core Частота: 2.4 ГГц Оперативная память: 8 Гб Видеокарта: Intel Iris Xe Graphics Дисплей: Диагональ экрана: 13.3 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 210,6 Толщина (мм): 16,9 Длина (мм): 309,9 Вес (г): 1200",
                            ImagePath = "",
                            Name = "Ноутбук ASUS ExpertBook B5 13.3\"",
                            Price = 81990m
                        },
                        new
                        {
                            Id = new Guid("fc0ffabf-3cd2-45f9-af8b-3beb58c18f4e"),
                            Category = "Ноутбук",
                            Description = "Процессор и память: Количество ядер процессора: Dual-Core Частота: 3.0ГГц Оперативная память: 8 Гб Видеокарта: Intel UHD Graphics Дисплей: Диагональ экрана: 15.6 Разрешение дисплея: 1920 x 1080 Внешний вид: Ширина (мм): 363.96 Толщина (мм): 19 Длина (мм): 249 Вес (г): 1780",
                            ImagePath = "",
                            Name = "Ноутбук DELL Vostro 3500, 15.6\"",
                            Price = 35990m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
