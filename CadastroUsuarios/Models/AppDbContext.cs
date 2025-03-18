using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core, necessário para manipulação do banco de dados.

namespace CadastroUsuarios.Models
{
    // Classe que representa o contexto do banco de dados e gerencia as entidades da aplicação.
    public class AppDbContext : DbContext
    {
        // Construtor que recebe as opções do contexto e as repassa para a classe base 'DbContext'
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // O 'options' contém as configurações do banco de dados, como a string de conexão.
        // O ': base(options)' chama o construtor da classe pai (DbContext) para aplicar essas configurações.

        // Criação da tabela 'Usuarios' no banco de dados, baseada no modelo 'Usuario'.
        public DbSet<Usuario> Usuarios { get; set; }
        // O 'DbSet<Usuario>' representa a tabela no banco de dados, permitindo CRUD (Create, Read, Update, Delete).
    }
}
