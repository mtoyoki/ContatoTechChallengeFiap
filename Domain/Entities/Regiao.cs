using Core.Entities;

namespace Domain.Entities
{
    public class Regiao: BaseEntity
    {
        public string Descricao { get; set; }
        public string Uf { get; set; }


        public Regiao()
        {            
        }

        public Regiao(int id, string descricao, string uf)
        {
            Id = id;
            Descricao = descricao;
            Uf = uf;
        }
    }
}
