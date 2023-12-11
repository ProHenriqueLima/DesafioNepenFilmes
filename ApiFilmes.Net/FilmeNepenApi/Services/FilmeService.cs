using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using FilmeNepenApi.Repositories;
using Microsoft.AspNetCore.Components.Forms;
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
        public Filme[] ListarFilmes(string? pesquisa,string user)
        {
            Filme[] filmes;
            filmes = _repo.GetAllFilmes();
            if(pesquisa != null && pesquisa != "")
            {
                filmes = filmes.Where(objeto => objeto.Nome.Contains(pesquisa) || objeto.Descricao.Contains(pesquisa) || objeto.AnoLancamento.ToString().Contains(pesquisa)).ToArray();
            }
            
            return filmes.Where(objeto => objeto.UsernameCriador == user).ToArray();
        }

        public Filme AdicionarFilmes(Filme? filme)
        {
            
            _repo.Add(filme);
            _repo.SaveChanges();
            return filme;
        }

        public bool FilmeExistente(string nome,string user)
        {
            var filmes = _repo.GetAllFilmes();
            filmes = filmes.Where(objeto => objeto.Nome == nome && objeto.UsernameCriador == user).ToArray();
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
                _contexto.Entry(filme).CurrentValues.SetValues(filmeEditado);
                _repo.Update(filme);
                _repo.SaveChanges();
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
