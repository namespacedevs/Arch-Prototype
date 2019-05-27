using ArchPrototype.Domain.Core.Models;
using ArchPrototype.Domain.Core.Pipeline;
using MediatR;

namespace ArchPrototype.Domain.Classificacao.Commands
{
    public class ObterTodasClassificacoesCommand : IRequest<Response>
    {
    }
}