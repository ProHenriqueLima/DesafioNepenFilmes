using FilmeNepenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeNepenApi.Services
{
    public interface IFilmeService
    {
        Filme AdicionarFilmes(Filme? filme);
        Filme[] ListarFilmes(string? pesquisa,string user);
        Filme AtualizarFilmes(int id, Filme filmeEditado);
        bool FilmeExistente(string nome,string user);
        bool FilmeExistenteId(int id);
    }
}
