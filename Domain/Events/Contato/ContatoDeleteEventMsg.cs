using Core.Events;

namespace Domain.Events.Contato
{
    public class ContatoDeleteEventMsg : IEventMsg
    {
        public Guid EventMsgId { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}