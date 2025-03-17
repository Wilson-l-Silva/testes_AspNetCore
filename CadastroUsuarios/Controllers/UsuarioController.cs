using Microsoft.AspNetCore.Mvc;
using CadastroUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CadastroUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
       private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        public IActionResult Criar() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }
    }
}
