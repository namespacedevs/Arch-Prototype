using FluentValidation;
using PrototipoInterisk.Domain.Classificacao.Commands;

namespace PrototipoInterisk.ApplicationCore.Classificacao.Commands.Validators
{
    public class EditarClassificacaoValidator : AbstractValidator<EditarClassificacaoCommand>
    {
        public EditarClassificacaoValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .MinimumLength(1)
                .WithMessage("O nome deve possuir no mínimo 1 caractere.");

            RuleFor(a => a.Descricao)
                .NotEmpty()
                .WithMessage("A descrição é obrigatória.")
                .MinimumLength(1)
                .WithMessage("A descrição deve possuir no mínimo 1 caractere.");
            
            RuleFor(a => a.Status)
                .IsInEnum()
                .WithMessage("O status é obrigatória.");
        }
    }
}
