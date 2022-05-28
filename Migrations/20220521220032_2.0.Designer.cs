﻿// <auto-generated />
using System;
using DisneyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisneyAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220521220032_2.0")]
    partial class _20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("DisneyAPI.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CurrentObraId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.HasKey("GeneroId");

                    b.HasIndex("ObraId");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("DisneyAPI.Obra", b =>
                {
                    b.Property<int>("ObraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Califacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("ObraId");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("DisneyAPI.Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CurrentObraId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<float>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ObraId");

                    b.ToTable("Personajes");
                });

            modelBuilder.Entity("DisneyAPI.Genero", b =>
                {
                    b.HasOne("DisneyAPI.Obra", "Obra")
                        .WithMany("Generos")
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("DisneyAPI.Personaje", b =>
                {
                    b.HasOne("DisneyAPI.Obra", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("DisneyAPI.Obra", b =>
                {
                    b.Navigation("Generos");
                });
#pragma warning restore 612, 618
        }
    }
}