using ExemploApiCatalogoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Application.Interfaces
{
    public interface IAppServiceJogo
    {
        Task Adicionar(Jogo jogo); 
        Task Alterar(Jogo jogo);
        Task Excluir(Guid id);
        Task<IEnumerable<Jogo>> ObterTodosAsync();
        Task<Jogo> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Jogo>> ObterPorExprecaoAsync(Expression<Func<Jogo, bool>> predicate);
    }
}
