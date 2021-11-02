using ExemploApiCatalogoJogos.Data.Context;
using ExemploApiCatalogoJogos.Domain.Entities;
using ExemploApiCatalogoJogos.Domain.Interfaces.Repository;

namespace ExemploApiCatalogoJogos.Data.Repository
{
    public class RepositoryJogo : RepositoryBase<Jogo>, IRepositoryJogo
    {
        public RepositoryJogo(JogoContext context) : base(context) { }
    }
}
