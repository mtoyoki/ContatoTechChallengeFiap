using Core.Entities;

namespace Domain.Entities
{
    public class EventMessage: BaseEntity
    {
        public Guid EventMsgId { get; set; }
        public string EventMsg { get; set; }
        public string Result { get; set; }
        public string Details { get; set; }


        public EventMessage()
        {            
        }

        public EventMessage(Guid eventMsgId, string msg, string result, string details)
        {
            EventMsgId = eventMsgId;
            EventMsg = msg;
            Result = result;
            Details = details;
        }
    }
}
