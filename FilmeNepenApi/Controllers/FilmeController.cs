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

    [Authorize(Roles = "admin,usuario")]
    [HttpGet(Name = "ListarTodosFilmes")]
    public Filme[] ListarTodosFilmes(string? pesquisa)
    {
        return _servico.ListarFilmes(pesquisa);
    }
    
    [HttpPost(Name = "AdicionarFilme")]
    public IActionResult AdicionarFilme(Filme filme)
    {
        if(_servico.FilmeExistente(filme.Nome) == true)
        {
            return BadRequest("Já existe um filme com esse nome");
        }
        return Ok(_servico.AdicionarFilmes(filme));

    }

}
