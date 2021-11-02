using ExemploApiCatalogoJogos.Domain.Entities;
using ExemploApiCatalogoJogos.Domain.Interfaces;
using ExemploApiCatalogoJogos.Domain.Interfaces.Repository;
using ExemploApiCatalogoJogos.Domain.Interfaces.Service;
using ExemploApiCatalogoJogos.Domain.Validations;

namespace ExemploApiCatalogoJogos.Domain.Services
{
    public class DomainServiceJogo : DomainServiceBase<Jogo>, IServiceJogo
    {
      
        public DomainServiceJogo(IRepositoryJogo repositoryJogo,
                                 INotificador notificador) : 
                                 base(repositoryJogo, notificador)
        {

        }

        public bool Validar(Jogo jogo)
         => ExecutarValidacao(new ValidacaoJogo(), jogo);
    }
}
