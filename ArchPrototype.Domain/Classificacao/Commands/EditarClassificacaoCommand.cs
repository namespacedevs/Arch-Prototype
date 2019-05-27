using MediatR;
using ArchPrototype.Domain.Core.Enums;
using ArchPrototype.Domain.Core.Pipeline;

namespace PrototipoInterisk.Domain.Classificacao.Commands
{
    public class EditarClassificacaoCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }
    }
}