using ArchPrototype.Domain.Core.Models;
using ArchPrototype.Domain.Core.Pipeline;
using MediatR;

namespace ArchPrototype.Domain.Classificacao.Commands
{
    public class ObterClassificacaoCommand : IRequest<Response>
    {
        public ObterClassificacaoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}