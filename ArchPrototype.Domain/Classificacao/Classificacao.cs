using ArchPrototype.Domain.Core.Enums;

namespace PrototipoInterisk.Domain.Classificacao
{
    public class Classificacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public EStatus Status { get; set; }

        public Classificacao()
        {
            Status = EStatus.Ativo;
        }
    }
}
