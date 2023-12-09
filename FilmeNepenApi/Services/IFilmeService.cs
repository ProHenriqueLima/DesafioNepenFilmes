using FilmeNepenApi.Models;

namespace FilmeNepenApi.Services
{
    public interface IFilmeService
    {
        Filme[] ListarFilmes(string? pesquisa);
    }
}
