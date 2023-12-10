using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Controllers.Login
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        public UsuarioController(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar([FromBody] Usuario admin)
        {
            Usuario adm = new Usuario();
            adm = _authService.Login(admin.Username, admin.Password);
            if (adm == null)
            {
                return BadRequest(new { error = "Usuário ou senha inválidos" });
            }

            if (adm.Ativo == 0)
            {
                return BadRequest(new { error = "Usuário Inativo !" });
            }

            var token = TokenService.GenerateToken(adm);


            adm.Password = "";
            return new { adm = adm, token = token };

        }

        [HttpPost]
        [Route("cadastrarUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Cadastrar([FromBody] Usuario admin)
        {
            if (_authService.GetUsuario(admin.Username) != null)
            {
               return BadRequest(new { error = "Nome de usuário já cadastrado" });
            }
            await _authService.Cadastrar(admin);
            return (new { message = "Usuário cadastrado com sucesso !" });

        }

        [HttpPut]
        [Route("admin/editarUsuario")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<dynamic>> EditarAdminAdm(int id, Usuario adminEditado)
        {

            Usuario admin = new Usuario();
            admin = await _authService.PutUsuarioAdm(id, adminEditado);
            if (admin == null)
            {
                return BadRequest(new { error = "Falha ao editar usuário" });
            }

            return (new { message = "Usuário editado com sucesso !" });
        }

        [HttpPut]
        [Route("editarUsuario")]
        [Authorize]
        public async Task<ActionResult<dynamic>> EditarAdmin(int id, Usuario adminEditado)
        {

            Usuario admin = new Usuario();
            admin = await _authService.PutUsuario(id, adminEditado);
            if (admin == null)
            {
                return BadRequest(new { error = "Falha ao editar usuário" });
            }

            return (new { message = "Usuário editado com sucesso !" });
        }
        [HttpDelete]
        [Route("admin/deletarUsuario")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<dynamic>> DeleteAdminAdm(int id)
        {

            bool usuario = await _authService.DeleteUsuario(id);
            if (usuario == false)
            {
                return BadRequest(new { error = "Falha ao deletar usuário" });
            }

            return (new { message = "Usuário deletado com sucesso !" });
        }
    }
}