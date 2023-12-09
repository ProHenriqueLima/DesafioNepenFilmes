using FilmeNepenApi.Data;
using FilmeNepenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeNepenApi.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Filme[] GetAllFilmes()
        {
            IQueryable<Filme> query = _context.Filmes;

            query = query.AsNoTracking().OrderByDescending(u => u.Id);
            return query.ToArray();
        }
    }
}
