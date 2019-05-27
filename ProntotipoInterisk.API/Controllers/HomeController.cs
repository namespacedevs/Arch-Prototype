using System.Web.Http;
using MediatR;

namespace ProntotipoInterisk.API.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public object Get() => new { version = "Version 1.0" };
    }
}