using Application.Handlers.Contato.Db;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using Moq;
using Shared.Tests.Builders.Commands;

namespace Application.Tests.Contato.CommandHandlers
{
    public class DeleteContatoCommandHandlerTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly ContatoDeleteCommandHandler _commandHandler;
        private int contatoIdMock = 1;

        public DeleteContatoCommandHandlerTest()
        {

            // Mock Contato Repository
            var contatoMock = new ContatoBuilder()
                                    .Default()
                                    .Build();

            _contatoRepository = new Mock<IContatoRepository>();

            _contatoRepository.Setup(r => r.GetById(contatoIdMock))
                              .Returns(contatoMock);

            // Create CommandValidator and CommandHandler
            var commandValidator = new ContatoDeleteCommandValidator(_contatoRepository.Object);

            _commandHandler = new ContatoDeleteCommandHandler(commandValidator,
                                                              _contatoRepository.Object);
        }

        [Fact]
        public void Delete_Command_Valid()
        {
            //Arrange
            var command = new ContatoDeleteCommand
            {
                Id = contatoIdMock
            };

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.True(result.Success);
            _contatoRepository.Verify(c => c.Delete(It.IsAny<int>()),
                                                    Times.Once);
        }

        [Fact]
        public void Delete_Command_Invalid()
        {
            //Arrange
            var contatoIdInvalid = 999;

            var command = new ContatoDeleteCommand
            {
                Id = contatoIdInvalid
            };

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.False(result.Success);
            _contatoRepository.Verify(c => c.Delete(It.IsAny<int>()),
                                                    Times.Never);
        }
    }
}