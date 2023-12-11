using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Controllers.Login
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas aos usuários.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        /// <summary>
        /// Construtor da classe UsuarioController.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        /// <param name="authService">Serviço de autenticação.</param>
        public UsuarioController(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        /// <summary>
        /// Realiza a autenticação do usuário.
        /// </summary>
        /// <param name="admin">Objeto contendo as credenciais do usuário.</param>
        /// <returns>Informações do usuário e token de autenticação.</returns>
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

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="admin">Objeto contendo as informações do usuário a ser cadastrado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
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

        /// <summary>
        /// Edita um usuário com o papel de administrador.
        /// </summary>
        /// <param name="id">Identificador do usuário a ser editado.</param>
        /// <param name="adminEditado">Objeto contendo as informações do usuário editado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
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

        /// <summary>
        /// Edita um usuário.
        /// </summary>
        /// <param name="id">Identificador do usuário a ser editado.</param>
        /// <param name="adminEditado">Objeto contendo as informações do usuário editado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
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

        /// <summary>
        /// Deleta um usuário com o papel de administrador.
        /// </summary>
        /// <param name="id">Identificador do usuário a ser deletado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
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

        /// <summary>
        /// Verifica se o usuário está autenticado.
        /// </summary>
        /// <returns>Mensagem indicando que o usuário está autenticado.</returns>
        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Autenticado()
        {
            return (new { message = "Autenticado" });
        }
    }
}