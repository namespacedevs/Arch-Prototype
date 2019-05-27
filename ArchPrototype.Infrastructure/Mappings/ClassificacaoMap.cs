using System.Data.Entity.ModelConfiguration;
using ArchPrototype.Domain.Classificacao;

namespace ArchPrototype.Infrastructure.Mappings
{
    public class ClassificacaoMap : EntityTypeConfiguration<Classificacao>
    {
        public ClassificacaoMap()
        {
            ToTable("tb_classificacao");
            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Descricao).IsRequired().HasColumnType("varchar").HasMaxLength(256);
            Property(x => x.Status).IsRequired().HasColumnType("int");
        }
    }
}