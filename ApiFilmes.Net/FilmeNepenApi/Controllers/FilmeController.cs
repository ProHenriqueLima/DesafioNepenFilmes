using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using FilmeNepenApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas aos filmes.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IFilmeService _servico;

        /// <summary>
        /// Construtor da classe FilmeController.
        /// </summary>
        /// <param name="repo">Repositório para interação com o banco de dados.</param>
        /// <param name="service">Serviço para manipulação de filmes.</param>
        public FilmeController(IRepository repo, IFilmeService service)
        {
            _repo = repo;
            _servico = service;
        }

        /// <summary>
        /// Obtém todos os filmes, com a capacidade de aplicar filtros de pesquisa.
        /// </summary>
        /// <param name="pesquisa">Termo de pesquisa para filtrar os filmes.</param>
        /// <returns>Array de filmes correspondentes aos critérios de pesquisa.</returns>
        [Authorize(Roles = "admin,usuario")]
        [HttpGet(Name = "ListarTodosFilmes")]
        public Filme[] ListarTodosFilmes(string? pesquisa)
        {
            return _servico.ListarFilmes(pesquisa, User.Identity.Name);
        }

        /// <summary>
        /// Adiciona um novo filme.
        /// </summary>
        /// <param name="filme">Informações do filme a ser adicionado.</param>
        /// <returns>Resultado da operação de adição do filme.</returns>
        [Authorize(Roles = "admin,usuario")]
        [HttpPost(Name = "AdicionarFilme")]
        public IActionResult AdicionarFilme(Filme filme)
        {
            if (_servico.FilmeExistente(filme.Nome, User.Identity.Name))
            {
                return BadRequest("Já existe um filme com esse nome");
            }
            filme.UsernameCriador = User.Identity.Name;
            return Ok(_servico.AdicionarFilmes(filme));
        }

        /// <summary>
        /// Atualiza as informações de um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="filme">Informações atualizadas do filme.</param>
        /// <returns>Resultado da operação de atualização do filme.</returns>
        [Authorize(Roles = "admin,usuario")]
        [HttpPut(Name = "AtualizarFilme")]
        public IActionResult AtualizarFilme(Filme filme)
        {
            filme.UsernameCriador = User.Identity.Name;
            if (_servico.FilmeExistenteId(filme.Id))
            {
                return Ok(_servico.AtualizarFilmes(filme.Id, filme));
            }
            else
            {
                return BadRequest("Filme inexistente!");
            }
        }
    }
}
