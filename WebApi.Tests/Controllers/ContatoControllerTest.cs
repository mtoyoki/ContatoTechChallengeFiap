using Domain.Commands.Contato;
using Domain.Entities;
using Domain.Queries.Contato;
using FluentAssertions;
using Infra.Data.Repositories;
using Newtonsoft.Json;
using Shared.Tests.Builders.Commands;
using Shared.Tests.Builders.Entities;
using System.Net;
using System.Net.Http.Json;
using WebApi.Tests.Lib;
using Xunit;


namespace WebApi.Tests.Controllers
{
    public class ContatoControllerTest : ControllerBaseTest
    {
        private const string url = "api/contato";

        //[OneTimeSetUp]
        //public void OneTimeSetup()
        //{
        //    var dbContext = GetDbContext();
        //    _contatoRepository = new ContatoRepository(dbContext);
        //}

        //[SetUp]
        //public void SetUp()
        //{
        //    StartDatabase();
        //    ResetDatabase();
        //}

        [Fact]
        public void Create_Valid()
        {
            //Arrange
            StartDatabase();

            var regiao = new RegiaoBuilder().SaoPaulo().Build();

            var command = new CreateContatoCommandBuilder()
                                            .Default()
                                            .WithRegiaoId(regiao.Id)
                                            .Build();
            //Act
            var response = _httpClient.PostAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //(_contatoRepository.GetAllAsync().Result).Count().Should().Be(1);
            //ResetDatabase();
        }

        [Fact]
        public void Create_Invalid()
        {
            //Arrange
            StartDatabase();

            var nomeVazio = "";
            var regiao = new RegiaoBuilder().SaoPaulo().Build();

            var command = new CreateContatoCommandBuilder()
                                            .Default()
                                            .WithNome(nomeVazio)
                                            .WithRegiaoId(regiao.Id)
                                            .Build();
            //Act
            var response = _httpClient.PostAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            //var dbContext = GetDbContext();
            //_contatoRepository = new ContatoRepository(dbContext);
            //(_contatoRepository.GetAllAsync().Result).Count().Should().Be(0);
        }


        [Fact]
        public void Update_Valid()
        {
            //Arrange
            StartDatabase();

            var contato = CreateContatoAndSaveInDatabase();

            var nomeAlterado = "Nome alterado";

            var command = new UpdateContatoCommandBuilder()
                                .Default()
                                .WithId(contato.Id)
                                .WithNome(nomeAlterado)
                                .Build();

            //Act
            var response = _httpClient.PutAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //var dbContext = GetDbContext();
            //_contatoRepository = new ContatoRepository(dbContext);
            //var updatedContato = (_contatoRepository.GetAllAsync().Result).Single(c=> c.Id == contato.Id);
            //updatedContato.Nome.Should().Be(nomeUpdate);
        }

        [Fact]
        public void Update_Invalid_Empty()
        {
            //Arrange
            StartDatabase();

            Contato contato = CreateContatoAndSaveInDatabase();

            var nomeVazio = "";

            var command = new UpdateContatoCommandBuilder()
                                .Default()
                                .WithId(contato.Id)
                                .WithNome(nomeVazio)
                                .Build();

            //Act
            var response = _httpClient.PutAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Update_Invalid_NotExists()
        {
            //Arrange
            StartDatabase();

            var invalidId = 999;

            var command = new UpdateContatoCommandBuilder()
                                .Default()
                                .WithId(invalidId)
                                .Build();

            //Act
            var response = _httpClient.PutAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public void Delete_Valid()
        {
            //Arrange
            StartDatabase();

            var contato = CreateContatoAndSaveInDatabase();

            var command = new ContatoDeleteCommand()
            {
                Id = contato.Id,
            };

            //Act
            var response = _httpClient.DeleteAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //var deletedContato = (_contatoRepository.GetAllAsync().Result).SingleOrDefault(c => c.Id == contato.Id);
            //deletedContato.Should().BeNull();
        }


        [Fact]
        public void Delete_Invalid_Empty()
        {
            //Arrange
            StartDatabase();

            var command = new ContatoDeleteCommand();

            //Act
            var response = _httpClient.DeleteAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Delete_Invalid_NotExists()
        {
            //Arrange
            StartDatabase();

            var invalidId = 999;

            var command = new ContatoDeleteCommand()
            {
                Id = invalidId
            };

            //Act
            var response = _httpClient.DeleteAsJsonAsync(url, command).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void GetAll()
        {
            //Arrange
            StartDatabase();

            var regiao1 = new RegiaoBuilder().SaoPaulo().Build();
            var regiao2 = new RegiaoBuilder().RioDeJaneiro().Build();

            var contato1 = CreateContatoAndSaveInDatabase(regiao1);
            var contato2 = CreateContatoAndSaveInDatabase(regiao1);
            var contato3 = CreateContatoAndSaveInDatabase(regiao2);

            var countAll = 3;

            //Act
            var response = _httpClient.GetAsync(url).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = response.Content.ReadAsStringAsync().Result;
            var contatos = JsonConvert.DeserializeObject<IEnumerable<Contato>>(content);
            contatos.Should().HaveCount(countAll);
        }


        [Fact]
        public void GetByRegiaoId()
        {
            //Arrange
            StartDatabase();

            var regiao1 = new RegiaoBuilder().SaoPaulo().Build();
            var regiao2 = new RegiaoBuilder().RioDeJaneiro().Build();

            var contato1 = CreateContatoAndSaveInDatabase(regiao1);
            var contato2 = CreateContatoAndSaveInDatabase(regiao1);
            var contato3 = CreateContatoAndSaveInDatabase(regiao2);

            var idRegiao1 = regiao1.Id;
            var countRegiao1 = 2;

            var urlListar = $"{url}/listar-por-ddd/{idRegiao1}";

            //Act
            var response = _httpClient.GetAsync(urlListar).Result;

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = response.Content.ReadAsStringAsync().Result;
            var contatos = JsonConvert.DeserializeObject<IEnumerable<ContatoQueryResult>>(content);
            contatos.Should().HaveCount(countRegiao1);
        }


        private Contato CreateContatoAndSaveInDatabase(Regiao regiao = null)
        {
            regiao ??= new RegiaoBuilder().SaoPaulo().Build();

            var contato = new ContatoBuilder()
                                .Default()
                                .WithRegiaoId(regiao.Id)
                                .Build();

            var dbContext = GetDbContext();
            var contatoRepository = new ContatoRepository(dbContext);
            contatoRepository.Insert(contato);

            return contato;
        }
    }
}
