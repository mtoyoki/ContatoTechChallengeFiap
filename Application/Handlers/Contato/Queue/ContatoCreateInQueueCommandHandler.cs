using Application.AutoMapper;
using Core.Commands;
using Core.Queues;
using Domain.Commands.Contato;
using Domain.Events.Contato;
using FluentValidation;

namespace Application.Handlers.Contato.Queue
{
    public class ContatoCreateInQueueCommandHandler : CommandHandlerBase, ICommandHandler<ContatoCreateCommand>
    {
        private readonly IValidator<ContatoCreateCommand> _validator;
        private readonly IQueue<ContatoCreateEventMsg> _queue;

        public ContatoCreateInQueueCommandHandler(IValidator<ContatoCreateCommand> validator, IQueue<ContatoCreateEventMsg> queue)
        {
            _validator = validator;
            _queue = queue;
        }

        public Result Handle(ContatoCreateCommand command)
        {
            var eventMsgGuid = Guid.NewGuid();

            var validationResult = Validate(command, _validator);
            if (validationResult.IsValid)
            {
                var eventMsg = ContatoMapper.CommandToEventMsg(command, eventMsgGuid);
                _queue.PublishEvent(eventMsg);
            }

            return Result(eventMsgGuid.ToString());
        }
    }
}