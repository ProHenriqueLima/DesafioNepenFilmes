using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;

namespace FilmeNepenApi.Services
{
    public class FilmeService : IFilmeService
    {
        public readonly IRepository _repo;
        public FilmeService(IRepository repository)
        {
            _repo = repository;
        }
        public Filme[] ListarFilmes(string? pesquisa)
        {
            Filme[] filmes;
            filmes = _repo.GetAllFilmes();
            if(pesquisa != null && pesquisa != "")
            {
                filmes = filmes.Where(objeto => objeto.Nome.Contains(pesquisa) || objeto.Descricao.Contains(pesquisa) || objeto.AnoLancamento.ToString().Contains(pesquisa)).ToArray();
            }
            
            return filmes;
        }
    }
}
