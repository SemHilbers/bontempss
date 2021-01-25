﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210125192840_initialcreate1")]
    partial class initialcreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Gerecht", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GerechtSoortId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("GerechtSoortId");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("Gerechten");
                });

            modelBuilder.Entity("WebApplication1.Models.GerechtIngredient", b =>
                {
                    b.Property<int>("GerechtId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<short>("Aantal")
                        .HasColumnType("smallint");

                    b.HasKey("GerechtId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("GerechtIngredienten");
                });

            modelBuilder.Entity("WebApplication1.Models.GerechtSoort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Soort")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("GerechtSoorten");
                });

            modelBuilder.Entity("WebApplication1.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eenheid")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Ingredienten");
                });

            modelBuilder.Entity("WebApplication1.Models.Klanten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("Woonplaats")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Naam");

                    b.ToTable("Klantens");
                });

            modelBuilder.Entity("WebApplication1.Models.MenuGerecht", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("GerechtId")
                        .HasColumnType("int");

                    b.HasKey("MenuId", "GerechtId");

                    b.HasIndex("GerechtId");

                    b.ToTable("MenuGerechten");
                });

            modelBuilder.Entity("WebApplication1.Models.Menus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("WebApplication1.Models.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.Property<int?>("KlantenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tijd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KlantenId");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("WebApplication1.Models.ReserveringMenu", b =>
                {
                    b.Property<int>("ReserveringId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int?>("MenusId")
                        .HasColumnType("int");

                    b.HasKey("ReserveringId", "MenuId");

                    b.HasIndex("MenusId");

                    b.ToTable("ReserveringMenus");
                });

            modelBuilder.Entity("WebApplication1.Models.Gerecht", b =>
                {
                    b.HasOne("WebApplication1.Models.GerechtSoort", "Soort")
                        .WithMany("Gerechten")
                        .HasForeignKey("GerechtSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.GerechtIngredient", b =>
                {
                    b.HasOne("WebApplication1.Models.Gerecht", "Gerecht")
                        .WithMany("GerechtIngredienten")
                        .HasForeignKey("GerechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Ingredient", "Ingredient")
                        .WithMany("GerechtIngredienten")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.MenuGerecht", b =>
                {
                    b.HasOne("WebApplication1.Models.Gerecht", "Gerecht")
                        .WithMany("GerechtMenus")
                        .HasForeignKey("GerechtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Menus", "Menus")
                        .WithMany("MenuGerechten")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Reservering", b =>
                {
                    b.HasOne("WebApplication1.Models.Klanten", "Klanten")
                        .WithMany("Reserveringen")
                        .HasForeignKey("KlantenId");
                });

            modelBuilder.Entity("WebApplication1.Models.ReserveringMenu", b =>
                {
                    b.HasOne("WebApplication1.Models.Menus", "Menus")
                        .WithMany("ReserveringMenus")
                        .HasForeignKey("MenusId");

                    b.HasOne("WebApplication1.Models.Reservering", "Reservering")
                        .WithMany("ReserveringMenus")
                        .HasForeignKey("ReserveringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
