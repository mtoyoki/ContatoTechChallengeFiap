using AutoMapper;
using Domain.Entities;
using Domain.Events.Contato;
using Domain.Repositories;
using MassTransit;

namespace HostedService.ContatoCreateQueueConsumer
{

    public class QueueConsumer(IContatoRepository repository) : IConsumer<ContatoCreateEventMsg>
    {
        public Task Consume(ConsumeContext<ContatoCreateEventMsg> context)
        {
            Console.WriteLine(context.Message.ToString());

            var contato = MapEventMsgToEntity(context.Message);
            repository.Insert(contato);

            return Task.CompletedTask;
        }

        internal Contato MapEventMsgToEntity(ContatoCreateEventMsg message)
        {
            var config = new MapperConfiguration(configure => { configure.CreateMap<ContatoCreateEventMsg, Contato>(); });
            var mapper = config.CreateMapper();
            return mapper.Map<Contato>(message);
        }
    }
}