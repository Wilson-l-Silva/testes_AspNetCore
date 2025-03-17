using Microsoft.EntityFrameworkCore;
using ProjetoAspNetCoreBasico.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adiciona suporte a controllers


var app = builder.Build();

// Configurar Entity Framework Core com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//app.MapGet("/", () => "Hello World!");

// Servir arquivos estáticos (HTML, CSS, JS)
app.UseStaticFiles();
app.UseRouting();

app.MapControllers(); // Habilita os controllers


// Definir a página inicial como index.html
app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html"; // Definir o tipo de conteúdo como HTML
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();
