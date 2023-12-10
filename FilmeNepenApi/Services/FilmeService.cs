using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmeNepenApi.Services
{
    public class FilmeService : IFilmeService
    {
        public readonly IRepository _repo;
        public readonly DataContext _contexto;
        public FilmeService(IRepository repository, DataContext context)
        {
            _repo = repository;
            _contexto = context;
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
        
        public bool FilmeExistenteId(int id)
        {
            var filmes = _repo.GetAllFilmes();
            filmes = filmes.Where(objeto => objeto.Id == id).ToArray();
            if (filmes.Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        public Filme AtualizarFilmes(int id,Filme filmeEditado)
        {
            Filme filme = new Filme();
            try
            {

                filme = _contexto.Filmes.Find(id);
                filme.Id = id;
                filme.Nome = filmeEditado.Nome;
                filme.Descricao = filmeEditado.Descricao;
                filme.AnoLancamento = filmeEditado.AnoLancamento;
                filme.Banner = filmeEditado.Banner;
                _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                filme = new Filme();
            }

            return filme;
        }
    }
}
