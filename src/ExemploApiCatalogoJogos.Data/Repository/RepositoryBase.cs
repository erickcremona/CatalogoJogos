using ExemploApiCatalogoJogos.Data.Context;
using ExemploApiCatalogoJogos.Domain.Entities;
using ExemploApiCatalogoJogos.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private readonly JogoContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(JogoContext jogoContext)
        {
            _context = jogoContext;
            _dbSet = jogoContext.Set<TEntity>();
        }
        public void Adicionar(TEntity entity)
            => _dbSet.Add(entity);

        public void Alterar(TEntity entity)
            => _dbSet.Update(entity);

        public void Excluir(TEntity entity)
            => _dbSet.Remove(entity);

        public async Task<IEnumerable<TEntity>> ObterPorExprecaoAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task<TEntity> ObterPorIdAsync(Guid id)
            => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
            => await _dbSet.ToListAsync();

        public async Task<int> SaveChanges()
            => await _context.SaveChangesAsync();
               
        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();            
        
    }
}
