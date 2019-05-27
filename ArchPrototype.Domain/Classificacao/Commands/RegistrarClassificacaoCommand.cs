using ArchPrototype.Domain.Core.Models;
using ArchPrototype.Domain.Core.Pipeline;
using MediatR;

namespace ArchPrototype.Domain.Classificacao.Commands
{
    public class RegistrarClassificacaoCommand : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}