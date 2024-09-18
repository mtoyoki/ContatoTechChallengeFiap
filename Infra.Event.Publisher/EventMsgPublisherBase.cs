using MassTransit;

namespace Infra.EventPublisher
{
    public abstract class EventMsgPublisherBase(IBusControl bus, string queueName)
    {
        public async Task PublishEvent<TEvent>(TEvent eventMessage) where TEvent : class
        {
            var sendEndpoint = await bus.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await sendEndpoint.Send(eventMessage);
        }
    }
}