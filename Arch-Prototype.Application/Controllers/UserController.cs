using Arch_Prototype.Domain.Auth;
using Arch_Prototype.Infra.Data.Repositories;

namespace Arch_Prototype.Application.Controllers
{
    public class UserController : BaseController<User>
    {
        public UserController(IBaseRepository<User> repository) : base(repository)
        {
        }
    }
}