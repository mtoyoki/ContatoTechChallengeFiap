using Application.Contato;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using Moq;

namespace Application.Tests.Contato.CommandHandlers
{
    public class DeleteContatoCommandHandlerTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly DeleteContatoCommandHandler _commandHandler;

        public DeleteContatoCommandHandlerTest()
        {
            var contato = new Domain.Entities.Contato()
            {
                Id = 1,
                Nome = "José da Silva",
                Email = "jose@gmail.com",
                Telefone = "11972117173",
                RegiaoId = 11
            };

            _contatoRepository = new Mock<IContatoRepository>();
            _contatoRepository.Setup(r => r.GetById(contato.Id))
                              .Returns(contato);

            var commandValidator = new DeleteContatoCommandValidator(_contatoRepository.Object);

            _commandHandler = new DeleteContatoCommandHandler(commandValidator, _contatoRepository.Object);
        }

        [Fact]
        public void Should_Update_When_Command_Is_Valid()
        {
            //Arrange
            var command = new DeleteContatoCommand
            {
                Id = 1
            };

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.True(result.Success);
            _contatoRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Should_Not_Update_When_Command_Is_Invalid()
        {
            //Arrange
            var command = new DeleteContatoCommand
            {
            };

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.False(result.Success);
            _contatoRepository.Verify(c => c.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}