using Domain.Repositories;
using FluentAssertions;
using Infrastructure.Repositories;
using NUnit.Framework;
using Shared.Tests.Builders.Commands;
using System.Net;
using System.Net.Http.Json;

namespace WebApi.Tests.Controllers
{
    public class ContatoControllerTest : ControllerBaseTest
    {
        private const string url = "api/contato";

        private IContatoRepository _contatoRepository;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _contatoRepository = new ContatoRepository(GetDbContext());
        }

        [SetUp]
        public void SetUp()
        {
            StartDatabase();
            ResetDatabase();
        }

        [Theory]
        [TestCase("José da Silva", HttpStatusCode.OK, 1)]
        [TestCase("", HttpStatusCode.BadRequest, 0)]
        public void Create_Contato(string nome, HttpStatusCode httpStatusCode, int count)
        {
            //Arrange
            var regiaoSaoPaulo = new RegiaoBuilder().SaoPaulo().Build();
            var regiaoRioDeJaneiro = new RegiaoBuilder().RioDeJaneiro().Build();

            base.SeedData(regiaoSaoPaulo, regiaoRioDeJaneiro);

            var command = new CreateContatoCommandBuilder()
                                            .Default()
                                            .WithNome(nome)
                                            .WithRegiaoId(regiaoSaoPaulo.Id)
                                            .Build();


            //Act
            var httpResponseMessage = _httpClient.PostAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(httpStatusCode);
            (_contatoRepository.GetAllAsync().Result).Count().Should().Be(count);
        }
    }
}
