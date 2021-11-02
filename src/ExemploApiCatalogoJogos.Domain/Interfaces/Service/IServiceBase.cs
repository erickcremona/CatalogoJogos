using ExemploApiCatalogoJogos.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace ExemploApiCatalogoJogos.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {        
        void Notificar(ValidationResult validationResult);
        void Notificar(string mensagem);
    }
}
