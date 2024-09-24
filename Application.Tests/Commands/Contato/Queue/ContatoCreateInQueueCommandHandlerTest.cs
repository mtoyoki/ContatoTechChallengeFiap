using Application.Commands.Contato.Queue;
using Core.Queues;
using Domain.Commands.Contato.Validators;
using Domain.Events.Contato;
using Domain.Repositories;
using Moq;
using Shared.Tests.Builders.Commands;

namespace Application.Tests.Commands.Contato.Queue
{
    public class ContatoCreateInQueueCommandHandlerTest
    {
        private readonly Mock<IRegiaoRepository> _regiaoRepository;
        private readonly Mock<IQueue<ContatoCreateEventMsg>> _eventPublisher;
        private readonly ContatoCreateInQueueCommandHandler _commandHandler;

        public ContatoCreateInQueueCommandHandlerTest()
        {
            // Mock Event Publisher
            _eventPublisher = new Mock<IQueue<ContatoCreateEventMsg>>();

            // Mock Regiao Repository
            _regiaoRepository = new Mock<IRegiaoRepository>();

            var regiaoMock = new Domain.Entities.Regiao(11, "São Paulo", "SP");

            _regiaoRepository.Setup(r => r.GetById(regiaoMock.Id))
                             .Returns(regiaoMock);

            // Create CommandValidator and CommandHandler
            var createContatoCommandValidator = new ContatoCreateCommandValidator(_regiaoRepository.Object);

            _commandHandler = new ContatoCreateInQueueCommandHandler(createContatoCommandValidator, _eventPublisher.Object);
        }

        [Fact]
        public void Create_Command_Valid()
        {
            //Arrange
            var createContatoCommand = new CreateContatoCommandBuilder()
                                                        .Default()
                                                        .Build();

            //Act
            var result = _commandHandler.Handle(createContatoCommand);

            //Assert
            Assert.True(result.Success);
            _eventPublisher.Verify(c => c.PublishEvent(It.IsAny<Domain.Events.Contato.ContatoCreateEventMsg>()),
                                      Times.Once);
        }

        [Fact]
        public void Create_Command_Invalid()
        {
            //Arrange
            var createContatoCommand = new CreateContatoCommandBuilder()
                                                        .Empty()
                                                        .Build();

            //Act
            var result = _commandHandler.Handle(createContatoCommand);

            //Assert
            Assert.False(result.Success);
            _eventPublisher.Verify(c => c.PublishEvent(It.IsAny<Domain.Events.Contato.ContatoCreateEventMsg>()),
                                      Times.Never);
        }
    }
}