using MediatR;
using ArchPrototype.Domain.Core.Pipeline;

namespace PrototipoInterisk.Domain.Classificacao.Commands
{
    public class ObterClassificacaoCommand : IRequest<Response>
    {
        public ObterClassificacaoCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}