using FluentValidation;
using PrototipoInterisk.Domain.Classificacao.Commands;

namespace PrototipoInterisk.ApplicationCore.Classificacao.Commands.Validators
{
    public class ObterClassificacaoValidator : AbstractValidator<ObterClassificacaoCommand>
    {
        public ObterClassificacaoValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(0)
                .WithMessage("O código da categoria é requerido.");
        }
    }
}
