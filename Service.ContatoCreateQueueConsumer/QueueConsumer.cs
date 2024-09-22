using AutoMapper;
using Core.Validators;
using Domain.Entities;
using Domain.Events.Contato;
using Domain.Repositories;
using MassTransit;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service.ContatoCreateQueueConsumer
{

    public class QueueConsumer(
        IContatoRepository contatoRepository,
        IEventMessageRepository messageRepository,
        IEntityValidator<Contato> contatoValidator) : IConsumer<ContatoCreateEventMsg>
    {

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

                    var message = CreateSuccessMessage(eventMsg, contato);
                    messageRepository.Insert(message);
                }
                else
                {
                    var message = CreateErrorMessage(eventMsg, validationResult.Errors.ToString());
                    messageRepository.Insert(message);
                }
            }
            catch (Exception e)
            {
                var message = CreateErrorMessage(eventMsg, e);
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

        private static EventMessage CreateSuccessMessage(ContatoCreateEventMsg eventMsg, Contato contato)
        {
            var message = new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                "[SUCESSO] Contato foi inserido",
                contato.Id.ToString());
            return message;
        }

        private static EventMessage CreateErrorMessage(ContatoCreateEventMsg eventMsg, string errors)
        {
            var message = new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                "[ERRO] Contato não foi inserido",
                errors);
            return message;
        }

        private static EventMessage CreateErrorMessage(ContatoCreateEventMsg eventMsg, Exception e)
        {
            var message = new EventMessage(
                eventMsg.EventMsgId,
                eventMsg.ToString(),
                "[ERRO] Contato não foi inserido",
                e.Message);
            return message;
        }
    }
}