using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DisneyAPI;

namespace DisneyAPI.Data
{
    public partial class DataContext: DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<Personaje> Personajes { get; set; }   

        public DbSet<Obra> Obras { get; set; }  

        public DbSet<Genero> Generos { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;database=DisneyDb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<DisneyAPI.User>? User { get; set; }

    }


}
