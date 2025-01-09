using System;
using EFCoreConsole.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsole.DbContexts;

public class Context : DbContext
{
    public DbSet<Filme> Filmes { get; set; } // DbSet serve para criar a tabela com nome Filmes
    public DbSet<Diretor> Diretores { get; set; }
    public DbSet<Ator> Atores { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=EFCoreConsole.db");
}
