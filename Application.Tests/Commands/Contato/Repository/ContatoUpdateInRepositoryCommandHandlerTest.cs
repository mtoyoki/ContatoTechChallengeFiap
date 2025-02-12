﻿using Application.Commands.Contato.Repository;
using Domain.Commands.Contato.Validators;
using Domain.Repositories;
using Moq;
using Shared.Tests.Builders.Commands;
using Shared.Tests.Builders.Entities;

namespace Application.Tests.Commands.Contato.CommandHandlers
{
    public class ContatoUpdateInRepositoryCommandHandlerTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly Mock<IRegiaoRepository> _regiaoRepository;
        private readonly ContatoUpdateInRepositoryCommandHandler _commandHandler;

        private int contatoIdMock = 1;

        public ContatoUpdateInRepositoryCommandHandlerTest()
        {
            // Mock Contato Repository
            _contatoRepository = new Mock<IContatoRepository>();

            var contatoMock = new ContatoBuilder()
                                    .Default()
                                    .Build();

            _contatoRepository.Setup(r => r.GetById(contatoIdMock))
                              .Returns(contatoMock);

            // Mock Regiao Repository
            _regiaoRepository = new Mock<IRegiaoRepository>();

            var regiaoMock = new Domain.Entities.Regiao(11, "São Paulo", "SP");

            _regiaoRepository.Setup(r => r.GetById(regiaoMock.Id))
                             .Returns(regiaoMock);

            // Create CommandValidator and CommandHandler
            var commandValidator = new ContatoUpdateCommandValidator(_contatoRepository.Object, _regiaoRepository.Object);

            _commandHandler = new ContatoUpdateInRepositoryCommandHandler(commandValidator, _contatoRepository.Object);
        }

        [Fact]
        public void Update_Command_Valid()
        {
            //Arrange
            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithId(contatoIdMock)
                                        .Build();

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.True(result.Success);
            _contatoRepository.Verify(c => c.Update(It.IsAny<Domain.Entities.Contato>()),
                                                    Times.Once);
        }

        [Fact]
        public void Update_Command_Invalid()
        {
            //Arrange
            var contatoIdInvalid = 999;

            var command = new UpdateContatoCommandBuilder()
                                        .Default()
                                        .WithId(contatoIdInvalid)
                                        .Build();

            //Act
            var result = _commandHandler.Handle(command);

            //Assert
            Assert.False(result.Success);
            _contatoRepository.Verify(c => c.Update(It.IsAny<Domain.Entities.Contato>()),
                                                    Times.Never);
        }

    }
}