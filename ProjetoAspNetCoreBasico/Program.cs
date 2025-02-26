var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Servir arquivos estáticos (HTML, CSS, JS)
app.UseStaticFiles();

// Definir a página inicial como index.html
app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html"; // Definir o tipo de conteúdo como HTML
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();
