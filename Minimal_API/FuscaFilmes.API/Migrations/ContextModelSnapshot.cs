﻿// <auto-generated />
using System;
using FuscaFilmes.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuscaFilmes.API.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.Property<int>("AtoresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilmesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AtoresId", "FilmesId");

                    b.HasIndex("FilmesId");

                    b.ToTable("AtorFilme");
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AwardsCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diretores");
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.HasOne("FuscaFilmes.API.Entities.Ator", null)
                        .WithMany()
                        .HasForeignKey("AtoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuscaFilmes.API.Entities.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Filme", b =>
                {
                    b.HasOne("FuscaFilmes.API.Entities.Diretor", "Diretor")
                        .WithMany("Filmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("FuscaFilmes.API.Entities.Diretor", b =>
                {
                    b.Navigation("Filmes");
                });
#pragma warning restore 612, 618
        }
    }
}
