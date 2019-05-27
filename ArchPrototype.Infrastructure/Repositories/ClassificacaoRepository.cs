using ArchPrototype.Infrastructure.Contexts;
using PrototipoInterisk.Domain.Classificacao;
using PrototipoInterisk.Domain.Classificacao.Contracts;

namespace ArchPrototype.Infrastructure.Repositories
{
    public class ClassificacaoRepository : Repository<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(EfDataContext context) : base(context)
        {
        }
    }
}