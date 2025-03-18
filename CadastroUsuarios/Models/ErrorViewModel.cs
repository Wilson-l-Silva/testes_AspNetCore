namespace CadastroUsuarios.Models // Define o namespace do projeto onde a classe está localizada.
{
    // Classe que representa um modelo de erro para exibir informações sobre problemas na aplicação.
    public class ErrorViewModel
    {
        // Propriedade que armazena o ID da requisição que gerou o erro.
        // O '?' indica que a string pode ser nula (nullable).
        public string? RequestId { get; set; }

        // Propriedade que retorna true se o RequestId não for nulo ou vazio.
        // Isso ajuda a verificar se existe um código de erro válido para exibição.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
