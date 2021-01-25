using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

           // Ik maak hiermee de relaties aan
            ModelBuilder.Entity<GerechtIngredient>()
                .HasKey(table => new
                {
                    table.GerechtId,
                    table.IngredientId
                });
            
            ModelBuilder.Entity<MenuGerecht>()
                .HasKey(table => new
                {
                    table.MenuId,
                    table.GerechtId
                });

            ModelBuilder.Entity<ReserveringMenu>()
                .HasKey(table => new
                {
                    table.ReserveringId,
                    table.MenuId
                });
            // Met deze code zorg ik ervoor dat de naam van het gerecht maar 1 keer op de bon komt als het meerdere keren besteld word, 
            // en dat het een index heeft voor makkelijkere zoekfuncties
            ModelBuilder.Entity<Gerecht>()
                .HasIndex(g => g.Naam)
                .IsUnique();

            ModelBuilder.Entity<Klanten>()
                .HasIndex(K => K.Naam);

            ModelBuilder.Entity<Klanten>()
                .HasIndex(K => K.Email);
        }

        public DbSet<Klanten> Klantens { get; set; }
        public DbSet<Reservering> Reserveringen { get; set; }
        public DbSet<ReserveringMenu> ReserveringMenus { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<MenuGerecht> MenuGerechten { get; set; }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<GerechtIngredient> GerechtIngredienten { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }
        public DbSet<GerechtSoort> GerechtSoorten { get; set; }
    }
}
