namespace CadastroUsuarios.Models // Define o namespace do projeto onde a classe est� localizada.
{
    // Classe que representa um modelo de erro para exibir informa��es sobre problemas na aplica��o.
    public class ErrorViewModel
    {
        // Propriedade que armazena o ID da requisi��o que gerou o erro.
        // O '?' indica que a string pode ser nula (nullable).
        public string? RequestId { get; set; }

        // Propriedade que retorna true se o RequestId n�o for nulo ou vazio.
        // Isso ajuda a verificar se existe um c�digo de erro v�lido para exibi��o.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
