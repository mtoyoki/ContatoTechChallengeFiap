using Application.Commands.Contato.Queue;
using Core.Queues;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Events.Contato;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Shared.Tests.Builders.Commands;

namespace Application.Tests.Commands.Contato.Queue
{
    public class ContatoUpdateInQueueCommandHandlerTest
    {
        private readonly Mock<IQueue<ContatoUpdateEventMsg>> _eventPublisher;

        public ContatoUpdateInQueueCommandHandlerTest()
        {
            // Mock Event Publisher
            _eventPublisher = new Mock<IQueue<ContatoUpdateEventMsg>>();
        }

        [Fact]
        public void Update_Command_Valid()
        {
            // Arrange

            // Mock Validator
            var validator = new Mock<IValidator<ContatoUpdateCommand>>();
            validator.Setup(r => r.Validate(It.IsAny<ContatoUpdateCommand>())).Returns(new ValidationResult());

            var updateContatoCommand = new UpdateContatoCommandBuilder()
                .Default()
                .Build();

            var _commandHandler = new ContatoUpdateInQueueCommandHandler(validator.Object, _eventPublisher.Object);

            // Act
            var result = _commandHandler.Handle(updateContatoCommand);

            // Assert
            Assert.True(result.Success);
            _eventPublisher.Verify(c => c.PublishEvent(It.IsAny<ContatoUpdateEventMsg>()), Times.Once);
        }

        [Fact]
        public void Update_Command_Invalid()
        {
            // Arrange

            // Mock Validator
            var validationResult = new ValidationResult(
                new List<ValidationFailure>
                {
                    new ValidationFailure("Nome", "Preenchimento do Nome é obrigatório")

                });
            var validator = new Mock<IValidator<ContatoUpdateCommand>>();
            validator.Setup(r => r.Validate(It.IsAny<ContatoUpdateCommand>())).Returns(validationResult);

            var updateContatoCommand = new UpdateContatoCommandBuilder()
                                                        .Empty()
                                                        .Build();

            var commandHandler = new ContatoUpdateInQueueCommandHandler(validator.Object, _eventPublisher.Object);

            // Act
            var result = commandHandler.Handle(updateContatoCommand);

            // Assert
            Assert.False(result.Success);
            _eventPublisher.Verify(c => c.PublishEvent(It.IsAny<ContatoUpdateEventMsg>()), Times.Never);
        }
    }
}
