using ArchPrototype.Domain.Core.Enums;
using ArchPrototype.Domain.Core.Models;
using ArchPrototype.Domain.Core.Pipeline;
using MediatR;

namespace ArchPrototype.Domain.Classificacao.Commands
{
    public class EditarClassificacaoCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }
    }
}