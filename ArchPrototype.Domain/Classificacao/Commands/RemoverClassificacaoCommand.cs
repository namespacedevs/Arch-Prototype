using MediatR;
using ArchPrototype.Domain.Core.Pipeline;

namespace PrototipoInterisk.Domain.Classificacao.Commands
{
    public class RemoverClassificacaoCommand : IRequest<Response>
    {
        public RemoverClassificacaoCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}