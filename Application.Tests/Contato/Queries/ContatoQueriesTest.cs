using Application.Queries.Contato;
using Domain.Queries.Contato;
using Domain.Repositories;
using Moq;
using Shared.Tests.Builders.Queries;

namespace Application.Tests.Contato.Queries
{
    public class ContatoQueriesTest
    {
        private readonly Mock<IContatoRepository> _contatoRepositoryMock;
        private readonly ContatoQueriesHandlerHandler _contatoQueries;

        public ContatoQueriesTest()
        {
            _contatoRepositoryMock = new Mock<IContatoRepository>();
            _contatoQueries = new ContatoQueriesHandlerHandler(_contatoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync()
        {
            // Arrange
            var contato1 = new ContatoQueryResultBuilder()
                                .Default()
                                .WithId(1)
                                .WithNome("João da Silva")
                                .Build();

            var contato2 = new ContatoQueryResultBuilder()
                                .Default()
                                .WithId(1)
                                .WithNome("Maria da Silva")
                                .Build();

            var expectedResults = new List<ContatoQueryResult>
            {
                contato1,
                contato2
            };

            _contatoRepositoryMock.Setup(repo => repo.GetAllAsync())
                                  .ReturnsAsync(expectedResults);

            // Act
            var results = await _contatoQueries.GetAllAsync();

            // Assert
            Assert.Equal(expectedResults, results);
            _contatoRepositoryMock.Verify(c => c.GetAllAsync(),
                                          Times.Once);

        }

        [Fact]
        public async Task GetByRegiaoIdAsync()
        {
            // Arrange
            int regiaoId = 11;

            var contato1 = new ContatoQueryResultBuilder()
                                .Default()
                                .WithId(1)
                                .WithNome("João da Silva")
                                .Build();

            var contato2 = new ContatoQueryResultBuilder()
                                .Default()
                                .WithId(1)
                                .WithNome("Maria da Silva")
                                .Build();

            var expectedResults = new List<ContatoQueryResult>
            {
                contato1,
                contato2
            };

            _contatoRepositoryMock.Setup(repo => repo.GetByRegiaoIdAsync(regiaoId))
                                  .ReturnsAsync(expectedResults);

            // Act
            var results = await _contatoQueries.GetByRegiaoIdAsync(regiaoId);

            // Assert
            Assert.Equal(expectedResults, results);
            _contatoRepositoryMock.Verify(c => c.GetByRegiaoIdAsync(regiaoId),
                                          Times.Once);
        }
    }
}
