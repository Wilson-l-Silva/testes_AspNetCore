using CadastroUsuarios.Models; // Importa o namespace que contém os modelos da aplicação.
using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core para configurar o banco de dados.

var builder = WebApplication.CreateBuilder(args); // Cria o construtor da aplicação web.


// Adiciona suporte ao padrão MVC (Model-View-Controller) na aplicação
builder.Services.AddControllersWithViews();


// Configuração do banco de dados usando Entity Framework Core com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// O método 'GetConnectionString' recupera a string de conexão definida no arquivo 'appsettings.json'


var app = builder.Build(); // Constrói a aplicação com as configurações definidas acima.


// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment()) // Verifica se a aplicação NÃO está rodando no modo de desenvolvimento
{
    app.UseExceptionHandler("/Home/Error"); // Define uma página de erro padrão para exibição de exceções.

    // O HSTS (HTTP Strict Transport Security) adiciona segurança forçando o uso de HTTPS
    app.UseHsts();
}

// Redireciona todas as requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita o uso de arquivos estáticos (CSS, JavaScript, imagens, etc.)
app.UseStaticFiles();

// Define o roteamento da aplicação
app.UseRouting();

// Habilita a autorização de usuários (caso haja autenticação configurada)
app.UseAuthorization();


// Define a rota padrão da aplicação: 
// Caso o usuário acesse a aplicação sem um controlador ou ação especificados,
// ele será direcionado para a ação 'Index' do controlador 'Usuario'.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}"
);


// Inicia a aplicação e começa a escutar as requisições
app.Run();
