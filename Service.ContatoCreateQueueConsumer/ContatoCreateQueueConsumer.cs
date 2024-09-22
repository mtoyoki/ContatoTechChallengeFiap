using AutoMapper;
using Core.Validators;
using Domain.Entities;
using Domain.Events.Contato;
using Domain.Repositories;
using MassTransit;
using Shared;

namespace Service.ContatoCreateQueueConsumer
{
    public class ContatoCreateQueueConsumer(
        IContatoRepository contatoRepository,
        IEventMessageRepository messageRepository,
        IEntityValidator<Contato> contatoValidator) : IConsumer<ContatoCreateEventMsg>
    {
        public const string QueueName = QueueNames.ContatoCreateQueue;

        public Task Consume(ConsumeContext<ContatoCreateEventMsg> context)
        {
            var eventMsg = context.Message;

            try
            {
                var contato = MapEventMsgToEntity(eventMsg);

                //TODO: Validador fake
                var validationResult = contatoValidator.ValidateInsert(contato);

                if (validationResult.IsValid)
                {
                    contatoRepository.Insert(contato);

                    var message = EventMessageFactory.CreateSuccessMessage(eventMsg, contato);
                    messageRepository.Insert(message);
                }
                else
                {
                    var message = EventMessageFactory.CreateErrorMessage(eventMsg, validationResult.Errors.ToString());
                    messageRepository.Insert(message);
                }
            }
            catch (Exception e)
            {
                var message = EventMessageFactory.CreateExceptionMessage(eventMsg, e);
                messageRepository.Insert(message);
            }

            return Task.CompletedTask;
        }

        private static Contato MapEventMsgToEntity(ContatoCreateEventMsg message)
        {
            var config = new MapperConfiguration(configure => { configure.CreateMap<ContatoCreateEventMsg, Contato>(); });
            var mapper = config.CreateMapper();
            return mapper.Map<Contato>(message);
        }
    }
}