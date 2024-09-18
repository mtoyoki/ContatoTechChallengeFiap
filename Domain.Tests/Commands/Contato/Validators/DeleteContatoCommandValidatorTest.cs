using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using FluentAssertions;
using Moq;
using Shared.Tests.Builders.Commands;

namespace Domain.Tests.Commands.Contato.Validators
{
    public class DeleteContatoCommandValidatorTest
    {
        private readonly int _idContatoMock = 1;
        private readonly Mock<IContatoRepository> _contatoRepositoryMock;
        private readonly ContatoDeleteCommandValidator _validator;

        public DeleteContatoCommandValidatorTest()
        {
            _contatoRepositoryMock = new Mock<IContatoRepository>();

            var contatoMock = new ContatoBuilder()
                                        .Default()
                                        .WithId(_idContatoMock)
                                        .Build();

            _contatoRepositoryMock.Setup(r => r.GetById(_idContatoMock))
                                  .Returns(contatoMock);

            _validator = new ContatoDeleteCommandValidator(_contatoRepositoryMock.Object);
        }
        
        [Fact]
        public void Id_Empty()
        {
            //Arrange
            var idInvalid = 0;

            var command = new DeleteContatoCommandBuilder()
                                            .WithId(idInvalid)
                                            .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do Id é obrigatório").Should().BeTrue();
        }


        [Fact]
        public void Id_Invalid()
        {
            //Arrange
            var idInvalid = 999;

            var command = new DeleteContatoCommandBuilder()
                                            .WithId(idInvalid)
                                            .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Não foi possível encontrar o Contato").Should().BeTrue();

        }


        [Fact]
        public void Id_Valid()
        {
            //Arrange
            var idContatoValid = _idContatoMock;

            var command = new DeleteContatoCommandBuilder()
                                            .WithId(idContatoValid)
                                            .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeTrue();
        }
    }
}