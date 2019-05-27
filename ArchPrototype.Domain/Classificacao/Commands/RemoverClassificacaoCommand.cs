using ArchPrototype.Domain.Core.Models;
using ArchPrototype.Domain.Core.Pipeline;
using MediatR;

namespace ArchPrototype.Domain.Classificacao.Commands
{
    public class RemoverClassificacaoCommand : IRequest<Response>
    {
        public RemoverClassificacaoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}