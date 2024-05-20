using Core.Entities;

namespace Domain.Entities
{
    public class Regiao: BaseEntity
    {
        public string Descricao { get; set; }

        public IEnumerable<Contato> Contatos { get; set; }

        public Regiao()
        {            
        }

        public Regiao(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
