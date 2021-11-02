using ExemploApiCatalogoJogos.Domain.Entities;
using ExemploApiCatalogoJogos.Domain.Interfaces;
using ExemploApiCatalogoJogos.Domain.Interfaces.Repository;
using ExemploApiCatalogoJogos.Domain.Interfaces.Service;
using ExemploApiCatalogoJogos.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace ExemploApiCatalogoJogos.Domain.Services
{
    public class DomainServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly INotificador _notificador;
        public DomainServiceBase(IRepositoryBase<TEntity> repositoryBase, INotificador notificador)
        {
            _repositoryBase = repositoryBase;
            _notificador = notificador;
        }
      
        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }

        public void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        public void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
       
