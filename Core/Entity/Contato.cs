namespace Core.Entity
{
    public class Contato: BaseEntity
    {
        public required string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int DddId { get; set; }

        public Ddd Ddd { get; set; }

        public Contato()
        {
        }

        public Contato(int id, string nome, string telefone, string email, int dddId)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            DddId = dddId;
        }

    }
}
