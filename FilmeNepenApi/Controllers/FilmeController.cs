using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using FilmeNepenApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    public readonly IRepository _repo;
    public readonly IFilmeService _servico;
    public FilmeController(IRepository repo, IFilmeService service)
    {
        _repo = repo;
        _servico = service;
    }

    /// <summary>
    /// M�todo respons�vel por retornar todos os Filmes, sendo capazes de serem filtrados.
    /// </summary>
    /// <param name="pesquisa"></param>
    /// <returns></returns>
    [HttpGet(Name = "ListarTodosFilmes")]
    public Filme[] ListarTodosFilmes(string? pesquisa)
    {
        return _servico.ListarFilmes(pesquisa);
    }

    /// <summary>
    /// M�todo respons�vel para adicionar um filme
    /// </summary>
    /// <param name="filme"></param>
    /// <returns></returns>
    [Authorize(Roles = "admin,usuario")]
    [HttpPost(Name = "AdicionarFilme")]
    public IActionResult AdicionarFilme(Filme filme)
    {
        if(_servico.FilmeExistente(filme.Nome) == true)
        {
            return BadRequest("J� existe um filme com esse nome");
        }
        return Ok(_servico.AdicionarFilmes(filme));

    }

    /// <summary>
    /// M�todo respons�vel para atualizar um filme
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filme"></param>
    /// <returns></returns>
    [Authorize(Roles = "admin,usuario")]
    [HttpPut(Name = "AtualizarFilme")]
    public IActionResult AtualizarFilme(int id, Filme filme)
    {
        if(_servico.FilmeExistenteId(filme.Id) == true)
        {
            return Ok(_servico.AtualizarFilmes(id,filme));
        }
        else
        {
            return BadRequest("Filme inexistente!");
        }

    }

}
