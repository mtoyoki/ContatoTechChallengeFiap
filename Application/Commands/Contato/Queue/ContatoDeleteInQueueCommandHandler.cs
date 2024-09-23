using Core.Commands;
using Core.Extensions;
using Core.Queues;
using Domain.Commands.Contato;
using Domain.Events.Contato;
using FluentValidation;

namespace Application.Commands.Contato.Queue
{
    public class ContatoDeleteInQueueCommandHandler(IValidator<ContatoDeleteCommand> validator, IQueue<ContatoDeleteEventMsg> queue) : ICommandHandler<ContatoDeleteCommand>
    {
        public CommandResult Handle(ContatoDeleteCommand command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
            {
                var eventMsgGuid = Guid.NewGuid();
                var eventMsg = new ContatoDeleteEventMsg()
                {
                    EventMsgId = eventMsgGuid,
                    Id = command.Id
                };

                queue.PublishEvent(eventMsg);

                return CommandResultFactory.CreateSuccessResult(eventMsgGuid.ToString());
            }

            return CommandResultFactory.CreateErrorResult(validationResult.ToErrorList());
        }
    }
}
