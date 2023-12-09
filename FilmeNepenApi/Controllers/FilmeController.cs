using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    public readonly IRepository _repo;
    public FilmeController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "ListarTodosFilmes")]
    public Filme[] ListarTodosFilmes()
    {
        return _repo.GetAllFilmes();
    }
    
    [HttpPost(Name = "AdicionarFilme")]
    public void AdicionarFilme(Filme filme)
    {
        _repo.Add(filme);
        _repo.SaveChanges();

    }

}
