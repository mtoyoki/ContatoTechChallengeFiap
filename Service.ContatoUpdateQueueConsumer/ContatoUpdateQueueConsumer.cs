using AutoMapper;
using Domain.Entities;
using Domain.Events.Contato;
using Domain.Factories;
using Domain.Repositories;
using MassTransit;
using Shared;

namespace Service.ContatoUpdateQueueConsumer
{
    public class ContatoUpdateQueueConsumer(IContatoRepository contatoRepository, IEventMessageRepository messageRepository) : IConsumer<ContatoUpdateEventMsg>
    {
        public const string QueueName = QueueNames.ContatoUpdateQueue;

        public Task Consume(ConsumeContext<ContatoUpdateEventMsg> context)
        {
            var eventMsg = context.Message;

            try
            {
                var contato = MapEventMsgToEntity(eventMsg);
                contatoRepository.Update(contato);

                var message = EventMessageFactory.CreateSuccessMessage(eventMsg, $"Contato foi atualizado (id = {contato.Id}) ");
                messageRepository.Insert(message);
            }
            catch (Exception e)
            {
                var message = EventMessageFactory.CreateExceptionMessage(eventMsg, e);
                messageRepository.Insert(message);
            }

            return Task.CompletedTask;
        }

        private static Contato MapEventMsgToEntity(ContatoUpdateEventMsg message)
        {
            var config = new MapperConfiguration(configure => { configure.CreateMap<ContatoUpdateEventMsg, Contato>(); });
            var mapper = config.CreateMapper();
            return mapper.Map<Contato>(message);
        }
    }
}