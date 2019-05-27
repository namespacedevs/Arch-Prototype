using FluentValidation;

namespace ArchPrototype.Domain.Classificacao.Commands.Validators
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