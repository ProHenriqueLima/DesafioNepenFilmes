using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using FilmeNepenApi.Services;
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

    [HttpGet(Name = "ListarTodosFilmes")]
    public Filme[] ListarTodosFilmes(string? pesquisa)
    {
        return _servico.ListarFilmes(pesquisa);
    }
    
    [HttpPost(Name = "AdicionarFilme")]
    public void AdicionarFilme(Filme filme)
    {
        _repo.Add(filme);
        _repo.SaveChanges();

    }

}
