using FluentValidation;
using PrototipoInterisk.Domain.Classificacao.Commands;

namespace PrototipoInterisk.ApplicationCore.Classificacao.Commands.Validators
{
    public class RemoverClassificacaoValidator : AbstractValidator<ObterClassificacaoCommand>
    {
        public RemoverClassificacaoValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(0)
                .WithMessage("O código da categoria é requerido.");
        }
    }
}