using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmeNepenApi.Controllers.Login
{
    /// <summary>
    /// Controller responsável pela autenticação de usuários.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        /// <summary>
        /// Construtor da classe AuthController.
        /// </summary>
        /// <param name="context">Contexto de dados para interação com o banco.</param>
        public AuthController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os usuários (apenas para administradores autenticados).
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAdmin()
        {
            return await _context.Usuarios.ToListAsync();
        }

        /// <summary>
        /// Obtém um usuário específico por ID (apenas para administradores autenticados).
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>O usuário correspondente ao ID especificado.</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Usuario>> GetAdmin(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /// <summary>
        /// Cria um novo usuário (apenas para administradores autenticados).
        /// </summary>
        /// <param name="user">Informações do usuário a ser criado.</param>
        /// <returns>O usuário recém-criado.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Usuario>> PostAdmin(Usuario user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = user.Id }, user);
        }
    }
}