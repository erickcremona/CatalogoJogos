using ExemploApiCatalogoJogos.Domain.Entities;
using FluentValidation;

namespace ExemploApiCatalogoJogos.Domain.Validations
{
    public class ValidacaoJogo : AbstractValidator<Jogo>
    {
        public ValidacaoJogo()
        {
            RuleFor(n => n.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(3, 100)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(n => n.Preco)
                .GreaterThanOrEqualTo(1)
                .WithMessage("O campo {PropertyName} precisa ser maior que 0")
                .LessThanOrEqualTo(1000)
               .WithMessage("O campo {PropertyName} precisa ser menor que 1000");

            RuleFor(n => n.Produtora)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
             .Length(1, 100)
             .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
