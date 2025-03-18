using Microsoft.AspNetCore.Mvc; // Importa a biblioteca necessária para criar controllers no ASP.NET Core MVC.
using CadastroUsuarios.Models; // Importa o namespace onde está definido o modelo de usuário.
using Microsoft.EntityFrameworkCore; // Importa o Entity Framework Core para manipulação do banco de dados.
using System.Threading.Tasks; // Importa o namespace necessário para trabalhar com operações assíncronas.

namespace CadastroUsuarios.Controllers
{
    // Define um controlador para gerenciar ações relacionadas aos usuários
    public class UsuarioController : Controller
    {
        // Declara um campo privado somente leitura para armazenar o contexto do banco de dados
        private readonly AppDbContext _context;

        // Construtor do controlador que recebe o contexto do banco de dados via injeção de dependência
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // Método que retorna a lista de usuários cadastrados no banco de dados e os exibe na view
        public async Task<IActionResult> Index()
        {
            // Obtém todos os usuários da tabela 'Usuarios' de forma assíncrona
            var usuarios = await _context.Usuarios.ToListAsync();

            // Retorna a view 'Index' e passa a lista de usuários como modelo
            return View(usuarios);
        }

        // Método para exibir a página de criação de um novo usuário
        public IActionResult Criar()
        {
            return View(); // Retorna a view que contém o formulário de cadastro
        }

        // Método HTTP POST que recebe os dados do formulário e os salva no banco de dados
        [HttpPost] // Define que este método deve ser acionado somente via requisição HTTP POST
        public async Task<IActionResult> Criar(Usuario usuario)
        {
            // Verifica se os dados enviados pelo formulário são válidos, baseando-se nas anotações do modelo
            if (ModelState.IsValid)
            {
                // Adiciona o usuário ao contexto do banco de dados
                _context.Usuarios.Add(usuario);

                // Salva as alterações no banco de dados de forma assíncrona
                await _context.SaveChangesAsync();

                // Redireciona o usuário para a página inicial do controlador após o cadastro ser concluído
                return RedirectToAction(nameof(Index));
            }

            // Caso os dados não sejam válidos, retorna a view de criação com os erros de validação
            return View(usuario);
        }
    }
}
