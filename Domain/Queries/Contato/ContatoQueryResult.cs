namespace Domain.Queries.Contato
{
    public class ContatoQueryResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }
        public string DescricaoRegiao { get; set; }


        public ContatoQueryResult(int id, string nome, string telefone, string email, int regiaoId, string descricaoRegiao)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            RegiaoId = regiaoId;
            DescricaoRegiao = descricaoRegiao;
        }

    }
}