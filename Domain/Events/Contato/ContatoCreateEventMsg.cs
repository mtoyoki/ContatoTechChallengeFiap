namespace Domain.Events.Contato
{
    public class ContatoCreateEventMsg
    {
        public Guid EventMsgId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Telefone: {Telefone}, Email: {Email}, RegiaoId: {RegiaoId}";
        }
    }
}