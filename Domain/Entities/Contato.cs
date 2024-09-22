using Core.Entities;
using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    public class Contato: BaseEntity, IContatoEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }

        public virtual Regiao Regiao { get; set; }

        public Contato()
        {
        }

        public Contato(int id, string nome, string telefone, string email, int regiaoId)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            RegiaoId = regiaoId;
        }

    }
}
