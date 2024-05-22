using Domain.Commands.Contato;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Infrastructure.Repositories;
using NUnit.Framework;
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
            var regiao = new Regiao(11, "SAO PAULO");
            base.SeedData(regiao);

            var command = new CreateContatoCommand
            {
                Nome = nome,
                Email = "jose@gmail.com",
                Telefone = "11972117173",
                RegiaoId = 11
            };

            //Act
            var httpResponseMessage = _httpClient.PostAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(httpStatusCode);
            (_contatoRepository.GetAllAsync().Result).Count().Should().Be(count);
        }
    }
}
