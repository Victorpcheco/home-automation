using HomeAutomation.Domain.Interfaces;
using HomeAutomation.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeAutomation.infrastructure.Repositories
{

    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositorioGenerico(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> ListarTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> ObterPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AtualizarAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
