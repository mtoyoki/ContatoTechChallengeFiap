﻿using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using FluentAssertions;
using FluentValidation;
using Moq;
using Shared.Tests.Builders.Commands;
using Shared.Tests.Builders.Entities;

namespace Domain.Tests.Commands.Contato.Validators
{
    public class UpdateContatoCommandValidatorTest
    {
        private readonly int _idContatoMock = 1;
        private readonly Mock<IContatoRepository> _contatoRepositoryMock;
        private readonly Mock<IRegiaoRepository> _regiaoRepositoryMock;
        private readonly ContatoUpdateCommandValidator _validator;

        public UpdateContatoCommandValidatorTest()
        {
            // Mock Regiao
            _regiaoRepositoryMock = new Mock<IRegiaoRepository>();

            var regiaoMock = new Domain.Entities.Regiao(11, "São Paulo", "SP");

            _regiaoRepositoryMock.Setup(r => r.GetById(regiaoMock.Id))
                                 .Returns(regiaoMock);
            

            //Mock Contato
            _contatoRepositoryMock = new Mock<IContatoRepository>();

            var contatoMock = new ContatoBuilder()
                                        .Default()
                                        .WithId(_idContatoMock)
                                        .Build();

            _contatoRepositoryMock.Setup(r => r.GetById(_idContatoMock))
                                  .Returns(contatoMock);

            _validator = new ContatoUpdateCommandValidator(_contatoRepositoryMock.Object, _regiaoRepositoryMock.Object);
        }
        
        [Fact]
        public void Id_Empty()
        {
            //Arrange
            var idInvalid = 0;

            var command = new UpdateContatoCommandBuilder()
                                            .Default()
                                            .WithId(idInvalid)
                                            .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do Id é obrigatório").Should().BeTrue();
        }


        [Fact]
        public void Id_Inexistent()
        {
            //Arrange
            var idInvalid = 999;

            var command = new UpdateContatoCommandBuilder()
                                            .Default()
                                            .WithId(idInvalid)
                                            .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Contato inexistente").Should().BeTrue();

        }


        [Fact]
        public void Id_Valid()
        {
            //Arrange
            var idContatoValid = _idContatoMock;

            var command = new UpdateContatoCommandBuilder()
                                            .Default()
                                            .WithId(idContatoValid)
                                            .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Nome_Empty(string nome)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithNome(nome)
                                        .Build();

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
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithNome(nome)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Nome inválido").Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        public void Email_Empty(string email)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithEmail(email)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do E-mail é obrigatório").Should().BeTrue();
        }

        [Theory]
        [InlineData("email.com.br")]
        [InlineData("email@combr")]
        public void Email_Invalid(string email)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithEmail(email)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "E-mail inválido").Should().BeTrue();
        }

        [Theory]
        [InlineData("email@email.com.br")]
        [InlineData("email@email.com")]
        [InlineData("email@email.net.br")]
        public void Email_Valid(string email)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithEmail(email)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeTrue();
        }



        [Theory]
        [InlineData("")]
        public void Telefone_Empty(string telefone)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithTelefone(telefone)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do Telefone é obrigatório").Should().BeTrue();
        }

        [Theory]
        [InlineData("11999999")]
        [InlineData("119999999999999")]
        public void Telefone_Invalid(string telefone)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithTelefone(telefone)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Telefone inválido").Should().BeTrue();
        }

        [Theory]
        [InlineData("11972117171")]
        public void Telefone_Valid(string telefone)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithTelefone(telefone)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeTrue();
        }





        [Theory]
        [InlineData(0)]
        public void RegionId_Empty(int regionId)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithRegiaoId(regionId)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Preenchimento do DDD (RegiaoId) é obrigatório").Should().BeTrue();
        }

        [Theory]
        [InlineData(10)]
        [InlineData(22)]
        [InlineData(100)]
        public void RegionId_Invalid(int regionId)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithRegiaoId(regionId)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Exists(e => e.ErrorMessage == "Número do DDD (RegiaoId) inválido").Should().BeTrue();
        }

        [Theory]
        [InlineData(11)]
        public void RegionId_Valid(int regionId)
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithRegiaoId(regionId)
                                        .Build();

            //Act
            var validationResult = _validator.Validate(command);

            //Assert
            validationResult.IsValid.Should().BeTrue();
        }

    }
}