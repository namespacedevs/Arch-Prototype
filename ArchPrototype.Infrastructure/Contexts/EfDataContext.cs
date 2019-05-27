using System.Data.Entity;
using ArchPrototype.Infrastructure.Mappings;
using PrototipoInterisk.Domain.Classificacao;

namespace ArchPrototype.Infrastructure.Contexts
{
    public class EfDataContext : DbContext
    {
        public EfDataContext() : base("data source=1511_MXTI\\SQLEXPRESS;initial catalog=PrototipoInterisk;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Classificacao> Classificacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClassificacaoMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
