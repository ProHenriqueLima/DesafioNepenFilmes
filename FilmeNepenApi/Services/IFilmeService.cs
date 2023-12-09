using FilmeNepenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Services
{
    public interface IFilmeService
    {
        Filme AdicionarFilmes(Filme? filme);
        Filme[] ListarFilmes(string? pesquisa);
        bool FilmeExistente(string nome);
    }
}
