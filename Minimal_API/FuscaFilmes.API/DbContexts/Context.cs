using System;
using FuscaFilmes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Filme> Filmes { get; set; } // DbSet serve para criar a tabela com nome Filmes
    public DbSet<Diretor> Diretores { get; set; }
    public DbSet<Ator> Atores { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacionamento entre Diretor e Filme
        modelBuilder.Entity<Diretor>()
            .HasMany(e => e.Filmes)
            .WithOne(e => e.Diretor)
            .HasForeignKey(e => e.DiretorId)
            .IsRequired();

        // Dados iniciais para Diretores
        modelBuilder.Entity<Diretor>().HasData(
            new Diretor { Id = 1, Name = "Christopher Nolan" },
            new Diretor { Id = 2, Name = "Walter Salles" },
            new Diretor { Id = 3, Name = "Quentin Tarantino" },
            new Diretor { Id = 4, Name = "Steven Spielberg" }
        );

        // Dados iniciais para Filmes
        modelBuilder.Entity<Filme>().HasData(
            new Filme { Id = 1, Titulo = "Ainda estou aqui", Ano = 2024, DiretorId = 2 },
            new Filme { Id = 2, Titulo = "Inception", Ano = 2010, DiretorId = 1 },
            new Filme { Id = 3, Titulo = "Pulp Fiction", Ano = 1994, DiretorId = 3 },
            new Filme { Id = 4, Titulo = "Jurassic Park", Ano = 1993, DiretorId = 4 },
            new Filme { Id = 5, Titulo = "Django Unchained", Ano = 2012, DiretorId = 3 },
            new Filme { Id = 6, Titulo = "E.T. the Extra-Terrestrial", Ano = 1982, DiretorId = 4 }
        );

        // Dados iniciais para Atores
        modelBuilder.Entity<Ator>().HasData(
            new Ator { Id = 1, Name = "Fernanda Torres", BirthDate = new DateTime(1965, 9, 15), Nationality = "Brasileira", Gender = "Feminino", AwardsCount = 5 },
            new Ator { Id = 2, Name = "Leonardo DiCaprio", BirthDate = new DateTime(1974, 11, 11), Nationality = "Americana", Gender = "Masculino", AwardsCount = 14 },
            new Ator { Id = 3, Name = "Uma Thurman", BirthDate = new DateTime(1970, 4, 29), Nationality = "Americana", Gender = "Feminino", AwardsCount = 8 },
            new Ator { Id = 4, Name = "Sam Neill", BirthDate = new DateTime(1947, 9, 14), Nationality = "Neozelandês", Gender = "Masculino", AwardsCount = 4 },
            new Ator { Id = 5, Name = "Jamie Foxx", BirthDate = new DateTime(1967, 12, 13), Nationality = "Americana", Gender = "Masculino", AwardsCount = 10 },
            new Ator { Id = 6, Name = "Henry Thomas", BirthDate = new DateTime(1971, 9, 9), Nationality = "Americana", Gender = "Masculino", AwardsCount = 3 }
        );

        // Relacionamento muitos-para-muitos entre Atores e Filmes
        modelBuilder.Entity<Filme>()
            .HasMany(f => f.Atores)
            .WithMany(a => a.Filmes)
            .UsingEntity<Dictionary<string, object>>(
                "AtorFilme",
                j => j.HasOne<Ator>().WithMany().HasForeignKey("AtoresId"),
                j => j.HasOne<Filme>().WithMany().HasForeignKey("FilmesId")
            );

        // Dados para a tabela intermediária AtorFilme (Atores que participam de filmes)
        modelBuilder.Entity("AtorFilme").HasData(
            new { AtoresId = 1, FilmesId = 1 }, // Fernanda Torres em "Ainda estou aqui"
            new { AtoresId = 2, FilmesId = 2 }, // Leonardo DiCaprio em "Inception"
            new { AtoresId = 3, FilmesId = 3 }, // Uma Thurman em "Pulp Fiction"
            new { AtoresId = 4, FilmesId = 4 }, // Sam Neill em "Jurassic Park"
            new { AtoresId = 5, FilmesId = 5 }, // Jamie Foxx em "Django Unchained"
            new { AtoresId = 6, FilmesId = 6 }, // Henry Thomas em "E.T. the Extra-Terrestrial"
            new { AtoresId = 2, FilmesId = 5 }, // Leonardo DiCaprio em "Django Unchained"
            new { AtoresId = 3, FilmesId = 4 }, // Uma Thurman em "Jurassic Park"
            new { AtoresId = 1, FilmesId = 3 }  // Fernanda Torres em "Pulp Fiction"
        );
    }
}
