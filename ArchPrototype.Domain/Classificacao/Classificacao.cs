using ArchPrototype.Domain.Core.Enums;

namespace ArchPrototype.Domain.Classificacao
{
    public class Classificacao
    {
        public Classificacao()
        {
            Status = EStatus.Ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }
    }
}