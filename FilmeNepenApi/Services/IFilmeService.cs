using FilmeNepenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Services
{
    public interface IFilmeService
    {
        Filme AdicionarFilmes(Filme? filme);
        Filme[] ListarFilmes(string? pesquisa);
        Filme AtualizarFilmes(int id, Filme filmeEditado);
        bool FilmeExistente(string nome);
        bool FilmeExistenteId(int id);
    }
}
