using Application.Contato;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using Moq;

namespace Application.Tests.Contato.CommandHandlers
{
    public class UpdateContatoCommandHandlerTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly Mock<IRegiaoRepository> _regiaoRepository;
        private readonly UpdateContatoCommandHandler _commandHandler;

        public UpdateContatoCommandHandlerTest()
        {
            _contatoRepository = new Mock<IContatoRepository>();
            _regiaoRepository = new Mock<IRegiaoRepository>();

            var regiaoSaoPaulo = new Domain.Entities.Regiao(11, "São Paulo");          
            _regiaoRepository.Setup(r => r.GetById(regiaoSaoPaulo.Id))
                             .Returns(regiaoSaoPaulo);

            var commandValidator = new UpdateContatoCommandValidator(_regiaoRepository.Object);

            _commandHandler = new UpdateContatoCommandHandler(commandValidator, _contatoRepository.Object);
        }

        [Fact]
        public void Should_Update_When_Command_Is_Valid()
        {
            //Arrange
            var command = new UpdateContatoCommand
            {
                Id = 1,
                Nome = "José da Silva",
                Email = "jose@gmail.com",
                Telefone = "11972117173",
                RegiaoId = 11                  
            };

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.True(result.Success);
            _contatoRepository.Verify(c => c.Update(It.IsAny<Domain.Entities.Contato>()), Times.Once);
        }

        [Fact]
        public void Should_Not_Update_When_Command_Is_Invalid()
        {
            //Arrange
            var command = new UpdateContatoCommand
            {
                Id = 0,
                Nome = "",
                Email = "",
                Telefone = "",
                RegiaoId = 11
            };

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.False(result.Success);
            _contatoRepository.Verify(c => c.Update(It.IsAny<Domain.Entities.Contato>()), Times.Never);
        }

    }
}
