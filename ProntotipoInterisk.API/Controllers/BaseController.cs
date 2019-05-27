using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using ArchPrototype.Domain.Core.Pipeline;

namespace ProntotipoInterisk.API.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly IMediator Mediator = null;

        private HttpResponseMessage _responseMessage;

        public BaseController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        private void CreateResponseGenerics(HttpStatusCode code, object result)
        {
            _responseMessage = Request.CreateResponse(code, result);
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            CreateResponseGenerics(code, result);
            return Task.FromResult<HttpResponseMessage>(_responseMessage);
        }

        public Task<HttpResponseMessage> Response(Response response)
        {
            if (!response.Errors.Any())
            {
                try
                {
                    _responseMessage = Request.CreateResponse(response.Result == null  ? HttpStatusCode.NoContent : HttpStatusCode.OK, new
                    {
                        success = true,
                        data = response.Result
                    });
                }
                catch
                {
                    _responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                _responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, new
                {
                    success = false,
                    errors = response.Errors
                });
            }

            return Task.FromResult<HttpResponseMessage>(_responseMessage);
        }
    }
}