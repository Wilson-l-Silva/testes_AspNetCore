using Microsoft.EntityFrameworkCore;
using ProjetoAspNetCoreBasico.Domain.Entities;
using ProjetoAspNetCoreBasico.Infrastructure.Data;

namespace ProjetoAspNetCoreBasico.Infrastructure.Repositories
{
    public class PessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> ObterTodas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
