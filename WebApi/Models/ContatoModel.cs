namespace WebApi.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int DDD { get; set; }

        public ContatoModel()
        {
        }

        public ContatoModel(int id, string nome, string telefone, string email, int ddd)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            DDD = ddd;
        }

    }
}
