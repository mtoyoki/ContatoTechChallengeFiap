namespace Core.Queues
{
    public interface IQueue<in TEvent> where TEvent: class
    {
        Task PublishEvent<TEvent>(TEvent eventMessage) where TEvent : class;
    }
}