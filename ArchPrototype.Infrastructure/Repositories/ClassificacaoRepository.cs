using ArchPrototype.Domain.Classificacao;
using ArchPrototype.Domain.Classificacao.Contracts;
using ArchPrototype.Infrastructure.Contexts;

namespace ArchPrototype.Infrastructure.Repositories
{
    public class ClassificacaoRepository : Repository<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(EfDataContext context) : base(context)
        {
        }
    }
}