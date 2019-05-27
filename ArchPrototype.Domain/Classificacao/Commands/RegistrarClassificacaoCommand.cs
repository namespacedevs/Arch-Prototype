using MediatR;
using ArchPrototype.Domain.Core.Pipeline;

namespace PrototipoInterisk.Domain.Classificacao.Commands
{
    public class RegistrarClassificacaoCommand : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}