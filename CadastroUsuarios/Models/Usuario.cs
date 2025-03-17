using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarios.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Range(1, 120, ErrorMessage = "A idade deve estar entre 1 e 120 anos.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string Cpf { get; set; }


    }
}
