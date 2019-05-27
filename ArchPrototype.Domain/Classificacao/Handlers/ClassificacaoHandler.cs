using System.Threading;
using System.Threading.Tasks;
using ArchPrototype.Domain.Classificacao.Commands;
using ArchPrototype.Domain.Classificacao.Contracts;
using ArchPrototype.Domain.Core.Models;
using ArchPrototype.Domain.Core.Pipeline;
using MediatR;

namespace ArchPrototype.Domain.Classificacao.Handlers
{
    public class ClassificacaoHandler : IRequestHandler<ObterTodasClassificacoesCommand, Response>,
        IRequestHandler<ObterClassificacaoCommand, Response>,
        IRequestHandler<RegistrarClassificacaoCommand, Response>,
        IRequestHandler<EditarClassificacaoCommand, Response>,
        IRequestHandler<RemoverClassificacaoCommand, Response>
    {
        private readonly IClassificacaoRepository _classificacaoRepository;

        public ClassificacaoHandler(IClassificacaoRepository classificacaoRepository)
        {
            _classificacaoRepository = classificacaoRepository;
        }

        public async Task<Response> Handle(EditarClassificacaoCommand request, CancellationToken cancellationToken)
        {
            var classificacao = _classificacaoRepository.GetById(request.Id);
            classificacao.Nome = request.Nome;
            classificacao.Descricao = request.Descricao;
            classificacao.Status = request.Status;

            _classificacaoRepository.SaveChanges();

            return new Response(classificacao);
        }

        public async Task<Response> Handle(ObterClassificacaoCommand request, CancellationToken cancellationToken)
        {
            var classificacao = _classificacaoRepository.GetById(request.Id);

            return new Response(classificacao);
        }

        public async Task<Response> Handle(ObterTodasClassificacoesCommand request, CancellationToken cancellationToken)
        {
            var classificacoes = _classificacaoRepository.GetAll();

            return new Response(classificacoes);
        }

        public async Task<Response> Handle(RegistrarClassificacaoCommand request, CancellationToken cancellationToken)
        {
            var classificacao = new Classificacao
            {
                Nome = request.Nome,
                Descricao = request.Descricao
            };

            _classificacaoRepository.Add(classificacao);
            _classificacaoRepository.SaveChanges();

            return new Response(classificacao);
        }

        public async Task<Response> Handle(RemoverClassificacaoCommand request, CancellationToken cancellationToken)
        {
            var classificacao = _classificacaoRepository.GetById(request.Id);
            _classificacaoRepository.Remove(classificacao);
            _classificacaoRepository.SaveChanges();

            return new Response(classificacao);
        }
    }
}