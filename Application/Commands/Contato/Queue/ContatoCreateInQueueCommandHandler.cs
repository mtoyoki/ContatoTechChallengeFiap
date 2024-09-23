using Application.AutoMapper;
using Core.Commands;
using Core.Extensions;
using Core.Queues;
using Domain.Commands.Contato;
using Domain.Events.Contato;
using FluentValidation;

namespace Application.Commands.Contato.Queue
{
    public class ContatoCreateInQueueCommandHandler(IValidator<ContatoCreateCommand> validator, IQueue<ContatoCreateEventMsg> queue) : ICommandHandler<ContatoCreateCommand>
    {
        public CommandResult Handle(ContatoCreateCommand command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
            {
                var eventMsgGuid = Guid.NewGuid();
                var eventMsg = ContatoMapper.CommandToEventMsg(command, eventMsgGuid);
                queue.PublishEvent(eventMsg);

                return CommandResultFactory.CreateSuccessResult(eventMsgGuid.ToString());
            }

            return CommandResultFactory.CreateErrorResult(validationResult.ToErrorList());
        }
    }
}