using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetCoreBasico.Models;

namespace ProjetoAspNetCoreBasico
{
    [Route("api/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private static List<Pessoa> listaPessoas = new();


        // Retorna todas as pessoas cadastradas
        [HttpGet]
        public IActionResult GetPessoas()
        {

            return Ok(listaPessoas);
        }


        [HttpPost]
        public IActionResult CriarPessoa([FromBody] Pessoa pessoa)
        {

            if (pessoa ==  null || string.IsNullOrEmpty(pessoa.Nome))
            {
                return BadRequest("Dados Inválidos");

            }

            listaPessoas.Add(pessoa);
            return Ok(new {mensagem = "Pessoa cadastrada com sucesso!"});
        }
    }
}
