namespace Core.Events
{
    public interface IEventMsg
    {
        Guid EventMsgId { get; set; }

        public string ToString();
    }
}