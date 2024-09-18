namespace Domain.Events.Contato
{
    public class ContatoCreateEventMsg
    {
        public Guid MessageId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }

        public override string ToString()
        {
            return $"EvtMsgId: { MessageId } Nome: {Nome}, Telefone: {Telefone}, Email: {Email}, RegiaoId: {RegiaoId}";
        }
    }
}