using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetCoreBasico.Domain.Entities;
using ProjetoAspNetCoreBasico.Infrastructure.Repositories;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaRepository _repository;

        public PessoaController(PessoaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var pessoas = await _repository.ObterTodas();
            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPessoa([FromBody] Pessoa pessoa)
        {
            if (pessoa == null || string.IsNullOrEmpty(pessoa.Nome))
            {
                return BadRequest("Dados inválidos.");
            }

            await _repository.Adicionar(pessoa);
            return Ok(new { mensagem = "Pessoa cadastrada com sucesso!" });
        }
    }
}
