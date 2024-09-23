using Core.Queues;
using Domain.Events.Contato;
using MassTransit;
using Shared;

namespace Infra.QueuePublisher.Contato
{
    public class ContatoDeleteQueuePublisher(IBusControl bus) : QueuePublisherBase(bus, QueueNames.ContatoDeleteQueue), IQueue<ContatoDeleteEventMsg>
    {
    }
}