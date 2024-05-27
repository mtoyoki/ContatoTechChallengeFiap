using Application.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Shared.Tests.Builders.Commands;

namespace Application.Tests.Contato.CommandHandlers
{
    public class CreateContatoCommandHandlerTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly Mock<IRegiaoRepository> _regiaoRepository;
        private readonly CreateContatoCommandHandler _createContatoCommandHandler;

        public CreateContatoCommandHandlerTest()
        {
            // Mock Contato Repository
            _contatoRepository = new Mock<IContatoRepository>();

            // Mock Regiao Repository
            _regiaoRepository = new Mock<IRegiaoRepository>();

            var regiaoMock = new Domain.Entities.Regiao(11, "São Paulo", "SP");

            _regiaoRepository.Setup(r => r.GetById(regiaoMock.Id))
                             .Returns(regiaoMock);

            // Create CommandValidator and CommandHandler
            var createContatoCommandValidator = new CreateContatoCommandValidator(_regiaoRepository.Object);

            _createContatoCommandHandler = new CreateContatoCommandHandler(createContatoCommandValidator,
                                                                           _contatoRepository.Object);
        }

        [Fact]
        public void Create_Command_Valid()
        {
            //Arrange
            var createContatoCommand = new CreateContatoCommandBuilder()
                                                        .Default()
                                                        .Build();

            //Act
            var result = _createContatoCommandHandler.Handle(createContatoCommand);

            //Assert
            Assert.True(result.Success);
            _contatoRepository.Verify(c => c.Insert(It.IsAny<Domain.Entities.Contato>()),
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
            var result = _createContatoCommandHandler.Handle(createContatoCommand);

            //Assert
            Assert.False(result.Success);
            _contatoRepository.Verify(c => c.Insert(It.IsAny<Domain.Entities.Contato>()),
                                                    Times.Never);
        }
    }
}