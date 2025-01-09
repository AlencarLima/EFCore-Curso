using System;

namespace FuscaFilmes.API.Entities;

public class Ator
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Filme> Filmes { get; set; } = [];
    public DateTime? BirthDate { get; set; }
    public string? Nationality { get; set; }
    public string? Gender { get; set; }
    public int AwardsCount { get; set; }
}
