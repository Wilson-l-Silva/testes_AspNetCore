using CadastroUsuarios.Models; // Importa o namespace que cont�m os modelos da aplica��o.
using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core para configurar o banco de dados.

var builder = WebApplication.CreateBuilder(args); // Cria o construtor da aplica��o web.


// Adiciona suporte ao padr�o MVC (Model-View-Controller) na aplica��o
builder.Services.AddControllersWithViews();


// Configura��o do banco de dados usando Entity Framework Core com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// O m�todo 'GetConnectionString' recupera a string de conex�o definida no arquivo 'appsettings.json'


var app = builder.Build(); // Constr�i a aplica��o com as configura��es definidas acima.


// Configura��o do pipeline de requisi��es HTTP
if (!app.Environment.IsDevelopment()) // Verifica se a aplica��o N�O est� rodando no modo de desenvolvimento
{
    app.UseExceptionHandler("/Home/Error"); // Define uma p�gina de erro padr�o para exibi��o de exce��es.

    // O HSTS (HTTP Strict Transport Security) adiciona seguran�a for�ando o uso de HTTPS
    app.UseHsts();
}

// Redireciona todas as requisi��es HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita o uso de arquivos est�ticos (CSS, JavaScript, imagens, etc.)
app.UseStaticFiles();

// Define o roteamento da aplica��o
app.UseRouting();

// Habilita a autoriza��o de usu�rios (caso haja autentica��o configurada)
app.UseAuthorization();


// Define a rota padr�o da aplica��o: 
// Caso o usu�rio acesse a aplica��o sem um controlador ou a��o especificados,
// ele ser� direcionado para a a��o 'Index' do controlador 'Usuario'.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}"
);


// Inicia a aplica��o e come�a a escutar as requisi��es
app.Run();
