using MassTransit;

namespace Infra.QueuePublisher
{
    public abstract class QueuePublisherBase(IBusControl bus, string queueName)
    {
        public async Task PublishEvent<TEvent>(TEvent eventMessage) where TEvent : class
        {
            var sendEndpoint = await bus.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await sendEndpoint.Send(eventMessage);
        }
    }
}