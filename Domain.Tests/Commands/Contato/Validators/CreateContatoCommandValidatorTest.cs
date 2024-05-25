using Domain.Commands.Contato;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Domain.Tests.Commands.Contato.Validators
{
    public class CreateContatoCommandValidatorTest
    {
        private readonly Mock<IRegiaoRepository> _regiaoRepositoryMock;
        private readonly CreateContatoCommandValidator _validator;

        public CreateContatoCommandValidatorTest()
        {
            _regiaoRepositoryMock = new Mock<IRegiaoRepository>();

            var regiaoSaoPaulo = new Domain.Entities.Regiao(11, "São Paulo");
            _regiaoRepositoryMock.Setup(r => r.GetById(regiaoSaoPaulo.Id))
                                 .Returns(regiaoSaoPaulo);

            _validator = new CreateContatoCommandValidator(_regiaoRepositoryMock.Object);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Nome_Empty(string nome)
        {
            //Arrange
            var command = new CreateContatoCommand()
            {
                Nome = nome,
                Email = "email@email.com.br",
                Telefone = "1197327272",
                RegiaoId = 11
            };

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do Nome é obrigatório").Should().BeTrue();
        }

        [Theory]
        [InlineData("ab")]
        [InlineData("abcdefghijklmnopqrstuvxyzabcdefghijklmnopqrstuvxyzabcdefghijklmnopqrstuvxyzabcdefghijklmnopqrstuvxyzlmnopqrstuvxyzabcdefghijklmnopqrstuvxyz")]
        public void Nome_Invalid(string nome)
        {
            //Arrange
            var command = new CreateContatoCommand()
            {
                Nome = nome,
                Email = "email@email.com.br",
                Telefone = "1197327272",
                RegiaoId = 11
            };

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Nome inválido").Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Email_Empty(string email)
        {
            //Arrange
            var command = new CreateContatoCommand()
            {
                Nome = "João da Silva",
                Email = email,
                Telefone = "1197327272",
                RegiaoId = 11
            };

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do E-mail é obrigatório").Should().BeTrue();
        }

        [Theory]
        [InlineData("email.com.br")]
        public void Email_Invalid(string email)
        {
            //Arrange
            var command = new CreateContatoCommand()
            {
                Nome = "João da Silva",
                Email = email,
                Telefone = "1197327272",
                RegiaoId = 11
            };

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "E-mail inválido").Should().BeTrue();
        }
    }
}
