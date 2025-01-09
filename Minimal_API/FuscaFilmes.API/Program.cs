using System.Text.Json.Serialization;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Entities;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:FilmesStr"])
);

// using (var context = new Context())
// {
//     context.Database.EnsureCreated();
// }

// Adicione serviços ao container.
builder.Services.AddEndpointsApiExplorer(); // Necessário para o Swagger.
builder.Services.AddSwaggerGen(); // Adiciona o Swagger.

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger.
    app.UseSwaggerUI(); // Configura a interface do Swagger.
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores.Include(diretor => diretor.Filmes).ToList();
});

app.MapPost("/diretores", (Context context, Diretor diretor) =>
{
    context.Diretores.Add(diretor);
    context.SaveChanges();
});

app.MapPut("/diretores/{diretorId}", (Context context, int diretorId, Diretor diretorNovo) => // diretor na URL não é necessário, apenas no corpo (json)
{
    var diretor = context.Diretores.Find(diretorId);

    if (diretor != null){
        diretor.Name = diretorNovo.Name;
        if (diretorNovo.Filmes.Count > 0) {
            diretor.Filmes.Clear();
            foreach(var filme in diretorNovo.Filmes){
                diretor.Filmes.Add(filme);
            }
        }
    }
    context.SaveChanges();
});

app.MapDelete("/diretores/{diretorId}", (Context context, int diretorId) =>
{
    var diretor = context.Diretores.Find(diretorId);
    
    if (diretor != null)
        context.Remove(diretor);
    context.SaveChanges();
})

.WithOpenApi(); // Adiciona as informações do endpoint ao Swagger.

app.Run();
