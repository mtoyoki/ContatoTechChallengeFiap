using Core.Queues;
using Domain.Events.Contato;
using MassTransit;
using Shared;

namespace Infra.QueuePublisher.Contato
{
    public class ContatoUpdateQueuePublisher(IBusControl bus) : QueuePublisherBase(bus, QueueNames.ContatoUpdateQueue), IQueue<ContatoUpdateEventMsg>
    {
    }
}