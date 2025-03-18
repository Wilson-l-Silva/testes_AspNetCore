using CadastroUsuarios.Models;
/*Importa o namespace onde está definida a classe Usuario.
 * Isso permite que essa classe seja usada na configuração do mapeamento.*/
using Microsoft.EntityFrameworkCore;
/*Importa o Entity Framework Core,
 * necessário para definir a configuração do banco de dados e suas entidades.*/
using Microsoft.EntityFrameworkCore.Metadata.Builders;
/*Importa a funcionalidade EntityTypeBuilder<T>, que é usada para configurar as propriedades da entidade Usuario,
 * como chaves primárias, índices e restrições de tamanho.*/

namespace CadastroUsuarios.Mappings
{
    // Classe de mapeamento para a entidade Usuario
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        // Método responsável por configurar o mapeamento da entidade Usuario no banco de dados
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Define o nome da tabela no banco de dados
            builder.ToTable("Usuarios");

            // Define a chave primária da tabela
            builder.HasKey(u => u.Id);

            // Configuração da coluna Nome
            builder.Property(u => u.Nome)
                .IsRequired() // Campo obrigatório
                .HasMaxLength(100); // Define um tamanho máximo de 100 caracteres

            // Configuração da coluna Idade
            builder.Property(u => u.Idade)
                .IsRequired(); // Campo obrigatório

            // Configuração da coluna Email
            builder.Property(u => u.Email)
                .IsRequired() // Campo obrigatório
                .HasMaxLength(150); // Define um tamanho máximo de 150 caracteres

            // Configuração da coluna CPF
            builder.Property(u => u.Cpf)
                .IsRequired() // Campo obrigatório
                .HasMaxLength(11); // Define um tamanho máximo de 11 caracteres

            // Criação de um índice único para o CPF, melhorando a performance nas buscas e garantindo que não haja CPFs duplicados
            builder.HasIndex(u => u.Cpf).IsUnique();
        }
    }
}