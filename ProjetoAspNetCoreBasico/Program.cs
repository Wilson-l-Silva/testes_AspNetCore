var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adiciona suporte a controllers


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Servir arquivos est�ticos (HTML, CSS, JS)
app.UseStaticFiles();
app.UseRouting();

app.MapControllers(); // Habilita os controllers


// Definir a p�gina inicial como index.html
app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html"; // Definir o tipo de conte�do como HTML
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();
