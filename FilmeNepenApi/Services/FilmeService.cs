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

        public Filme AdicionarFilmes(Filme? filme)
        {
            
            _repo.Add(filme);
            _repo.SaveChanges();
            return filme;
        }

        public bool FilmeExistente(string nome)
        {
            var filmes = _repo.GetAllFilmes();
            filmes = filmes.Where(objeto => objeto.Nome == nome).ToArray();
            if (filmes.Count() > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
