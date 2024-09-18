using Core.Queues;
using Domain.Events.Contato;
using MassTransit;
using Shared;

namespace Infra.EventPublisher.Contato
{
    public class ContatoCreateQueue(IBusControl bus) : EventMsgPublisherBase(bus, QueueNames.ContatoCreateQueue), IQueue<ContatoCreateEventMsg>
    {
    }
}