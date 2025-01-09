using System;
using FuscaFilmes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Filme> Filmes { get; set; } // DbSet serve para criar a tabela com nome Filmes
    public DbSet<Diretor> Diretores { get; set; }
    public DbSet<Ator> Atores { get; set; }
}
