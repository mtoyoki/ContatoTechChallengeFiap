using Domain.Entities;
using Domain.Events.Contato;
using Domain.Factories;
using Domain.Repositories;
using MassTransit;
using Shared;

namespace Service.ContatoDeleteQueueConsumer
{
    public class ContatoDeleteQueueConsumer(IContatoRepository contatoRepository, IEventMessageRepository messageRepository) : IConsumer<ContatoDeleteEventMsg>
    {
        public const string QueueName = QueueNames.ContatoDeleteQueue;

        public Task Consume(ConsumeContext<ContatoDeleteEventMsg> context)
        {
            var eventMsg = context.Message;

            try
            {
                var id = eventMsg.Id;
                contatoRepository.Delete(id);

                var message = EventMessageFactory.CreateSuccessMessage(eventMsg, $"Contato foi excluído (id = {id})");
                messageRepository.Insert(message);
            }
            catch (Exception e)
            {
                var message = EventMessageFactory.CreateExceptionMessage(eventMsg, e);
                messageRepository.Insert(message);
            }

            return Task.CompletedTask;
        }
    }
}