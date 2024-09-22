using Core.Queues;
using Domain.Events.Contato;
using MassTransit;
using Shared;

namespace Infra.QueuePublisher.Contato
{
    public class ContatoCreateQueuePublisher(IBusControl bus) : QueuePublisherBase(bus, QueueNames.ContatoCreateQueue), IQueue<ContatoCreateEventMsg>
    {
    }
}