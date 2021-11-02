using ExemploApiCatalogoJogos.Domain.Entities;

namespace ExemploApiCatalogoJogos.Domain.Interfaces.Service
{
    public interface IServiceJogo : IServiceBase<Jogo>
    {
        bool Validar(Jogo jogo);
    }
}
