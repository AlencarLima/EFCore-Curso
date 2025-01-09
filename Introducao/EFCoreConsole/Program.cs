using EFCoreConsole.DbContexts;
using EFCoreConsole.Entities;
using Microsoft.EntityFrameworkCore;

using (var context = new Context()) // cria ou assegura que o banco de dados foi criado
{
    context.Database.EnsureCreated();
}

using var db = new Context();

// db.Add(new Filme { Titulo = "Ainda estou aqui", Ano = 2024 });
// db.SaveChanges();
// var filme = db.Filmes.Find(1);
// if (filme != null) {
//     Console.WriteLine($"{filme.Id} {filme.Titulo}");
//     filme.Ano = 2024;
//     filme.Diretor = new Diretor() { Name = "Walter Salles"};
//     filme.Diretor.Name = "Walter Salles";
//     filme.Atores.Add(new Ator { Name = "Fernanda Torres" });
//     filme.Atores.Add(new Ator { Name = "Selton Mello" });
//     db.SaveChanges(); // faz o melhor comando que representa a modificação no db (no caso um UPDATE)
// }

// var filme = db.Filmes.Find(1);
// if (filme != null){
//     db.Remove(filme);
//     db.SaveChanges(); // faz o melhor comando que representa a modificação no db (no caso um DELETE)
// }

// var diretor = db.Diretores.Find(2);
// if (diretor != null){
//     db.Remove(diretor);
//     db.SaveChanges();
// }

var filmes = db.Filmes
    .Include(f => f.Diretor)
    .Include(f => f.Atores)
    .ToList();

foreach (var item in filmes)
{
    Console.WriteLine($"Filme: {item.Titulo}");
    if (item.Diretor != null)
        Console.WriteLine($"Diretor: {item.Diretor.Name}");
    if (item.Atores != null){
        Console.WriteLine("Atores:");
        foreach (var ator in item.Atores)
        {   
            Console.WriteLine($"    Ator: {ator.Name}");
        }
    }
}

Console.ReadLine();