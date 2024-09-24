namespace Domain.Queries.EventMessage
{
    public class EventMessageQueryResult
    {
        public Guid EventMsgId { get; set; }
        public string EventMsg { get; set; }
        public bool Result { get; set; }
        public string? Details { get; set; }

        public EventMessageQueryResult()
        {
        }

        public EventMessageQueryResult(Guid eventMsgId, string eventMsg, bool result, string? details)
        {
            EventMsgId = eventMsgId;
            EventMsg = eventMsg;
            Result = result;
            Details = details;
        }
    }
}