using Application.Contato;
using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using Moq;

namespace Application.Tests.Contato.CommandHandlers
{
    public class CreateContatoCommandHandlerTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly Mock<IRegiaoRepository> _regiaoRepository;
        private readonly CreateContatoCommandHandler _createContatoCommandHandler;

        public CreateContatoCommandHandlerTest()
        {
            _contatoRepository = new Mock<IContatoRepository>();
            _regiaoRepository = new Mock<IRegiaoRepository>();

            var regiaoSaoPaulo = new Domain.Entities.Regiao(11, "São Paulo");          
            _regiaoRepository.Setup(r => r.GetById(regiaoSaoPaulo.Id))
                             .Returns(regiaoSaoPaulo);

            var createContatoCommandValidator = new CreateContatoCommandValidator(_regiaoRepository.Object);

            _createContatoCommandHandler = new CreateContatoCommandHandler(createContatoCommandValidator,
                                                                           _contatoRepository.Object);
        }

        [Fact]
        public void Should_Create_When_Command_Is_Valid()
        {
            //Arrange
            var createContatoCommand = new CreateContatoCommand
            {
                Nome = "José da Silva",
                Email = "jose@gmail.com",
                Telefone = "11972117173",
                RegiaoId = 11                  
            };

            //Act
            var result = _createContatoCommandHandler.Handle(createContatoCommand);

            //Assert
            Assert.True(result.Success);
            _contatoRepository.Verify(c => c.Insert(It.IsAny<Domain.Entities.Contato>()), Times.Once);
        }

        [Fact]
        public void Should_Not_Create_When_Command_Is_Invalid()
        {
            //Arrange
            var createContatoCommand = new CreateContatoCommand
            {
                Nome = "",
                Email = "",
                Telefone = "",
                RegiaoId = 11
            };

            //Act
            var result = _createContatoCommandHandler.Handle(createContatoCommand);

            //Assert
            Assert.False(result.Success);
            _contatoRepository.Verify(c => c.Insert(It.IsAny<Domain.Entities.Contato>()), Times.Never);
        }

    }
}
