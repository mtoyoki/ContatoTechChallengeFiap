using Domain.Events.Contato;
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

                var message = EventMessageFactory.CreateSuccessMessage(eventMsg, id.ToString());
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