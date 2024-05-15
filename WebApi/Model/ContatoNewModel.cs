namespace WebApi.Model
{
    public class ContatoNewModel
    {
        public required string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int DDD { get; set; }

        public ContatoNewModel()
        {
        }

        public ContatoNewModel(string nome, string telefone, string email, int ddd)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            DDD = ddd;
        }

    }
}
