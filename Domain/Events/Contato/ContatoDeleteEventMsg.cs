namespace Domain.Events.Contato
{
    public class ContatoDeleteEventMsg
    {
        public Guid EventMsgId { get; set; }
        public int Id { get; set; }

        public ContatoDeleteEventMsg(Guid eventMsgGuid, int id)
        {
            this.EventMsgId = eventMsgGuid;
            Id = id;
        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}