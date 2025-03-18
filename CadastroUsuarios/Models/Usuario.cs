using System.ComponentModel.DataAnnotations; // Importa o namespace necessário para as validações dos campos.

namespace CadastroUsuarios.Models
{
    // Classe que representa a entidade 'Usuario' no banco de dados
    public class Usuario
    {
        // Campo que representa a chave primária da tabela no banco de dados.
        public int Id { get; set; }

        // Campo Nome - Obrigatório e com limite de 100 caracteres.
        [Required(ErrorMessage = "O nome é obrigatório")] // Validação: campo obrigatório
        [StringLength(100)] // Validação: permite no máximo 100 caracteres
        public string Nome { get; set; }

        // Campo Idade - Deve estar entre 1 e 120 anos.
        [Range(1, 120, ErrorMessage = "A idade deve estar entre 1 e 120 anos.")]
        public int Idade { get; set; }

        // Campo Email - Obrigatório e precisa ser um email válido.
        [Required(ErrorMessage = "O email é obrigatório.")] // Validação: campo obrigatório
        [EmailAddress(ErrorMessage = "Digite um email válido")] // Validação: verifica se o email é válido
        public string Email { get; set; }

        // Campo CPF - Obrigatório e deve ter exatamente 11 caracteres.
        [Required(ErrorMessage = "O CPF é obrigatório.")] // Validação: campo obrigatório
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")] // Validação: CPF deve ter exatamente 11 caracteres
        public string Cpf { get; set; }
    }
}
