using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ArchPrototype.Domain.Classificacao.Commands;
using MediatR;

namespace ProntotipoInterisk.API.Controllers
{
    [RoutePrefix("api")]
    public class ClassificacaoController : BaseController
    {
        public ClassificacaoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("classificacao")]
        public async Task<HttpResponseMessage> ObterTodos()
        {
            var response = await Mediator.Send(new ObterTodasClassificacoesCommand());
            return await Response(response);
        }

        [HttpGet]
        [Route("classificacao/{id}")]
        public async Task<HttpResponseMessage> Obter(int id)
        {
            var response = await Mediator.Send(new ObterClassificacaoCommand(id));
            return await Response(response);
        }

        [HttpPost]
        [Route("classificacao")]
        public async Task<HttpResponseMessage> Post([FromBody] RegistrarClassificacaoCommand model)
        {
            var response = await Mediator.Send(model);
            return await Response(response);
        }

        [HttpPut]
        [Route("classificacao/{id}")]
        public async Task<HttpResponseMessage> Editar(int id, [FromBody] EditarClassificacaoCommand model)
        {
            var response = await Mediator.Send(model);
            return await Response(response);
        }

        [HttpDelete]
        [Route("classificacao/{id}")]
        public async Task<HttpResponseMessage> Remover(int id)
        {
            var response = await Mediator.Send(new RemoverClassificacaoCommand(id));
            return await Response(response);
        }
    }
}