namespace Domain.Events.Contato
{
    public class ContatoUpdateEventMsg
    {
        public Guid EventMsgId { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Telefone: {Telefone}, Email: {Email}, RegiaoId: {RegiaoId}";
        }
    }
}