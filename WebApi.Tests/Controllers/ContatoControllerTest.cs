using Domain.Commands.Contato;
using Domain.Entities;
using Domain.Queries.Contato;
using Domain.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using Shared.Tests.Builders.Commands;
using System.Net;
using System.Net.Http.Json;
using Infra.Data.Repositories;
using Shared.Tests.Builders.Entities;
using WebApi.Tests.Lib;


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

        [Test]
        public void Create_Valid()
        {
            //Arrange
            var regiao = new RegiaoBuilder().SaoPaulo().Build();
            base.SeedData(regiao);

            var command = new CreateContatoCommandBuilder()
                                            .Default()
                                            .WithRegiaoId(regiao.Id)
                                            .Build();
            //Act
            var httpResponseMessage = _httpClient.PostAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            (_contatoRepository.GetAllAsync().Result).Count().Should().Be(1);
        }

        [Test]
        public void Create_Invalid()
        {
            //Arrange
            var regiao = new RegiaoBuilder().SaoPaulo().Build();
            base.SeedData(regiao);

            var empty = "";

            var command = new CreateContatoCommandBuilder()
                                            .Default()
                                            .WithNome(empty)
                                            .WithRegiaoId(regiao.Id)
                                            .Build();
            //Act
            var httpResponseMessage = _httpClient.PostAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            (_contatoRepository.GetAllAsync().Result).Count().Should().Be(0);
        }


        [Test]
        public void Update_Valid()
        {
            //Arrange
            Contato contato = CreateContatoEntity();

            var nomeUpdate = "Nome alterado";

            var command = new UpdateContatoCommandBuilder()
                                .Default()
                                .WithId(contato.Id)
                                .WithNome(nomeUpdate)
                                .Build();

            //Act
            var httpResponseMessage = _httpClient.PutAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

            var updatedContato = (_contatoRepository.GetAllAsync().Result).Single(c=> c.Id == contato.Id);
            updatedContato.Nome.Should().Be(nomeUpdate);
        }

        [Test]
        public void Update_Invalid_Empty()
        {
            //Arrange
            Contato contato = CreateContatoEntity();

            var empty = "";

            var command = new UpdateContatoCommandBuilder()
                                .Default()
                                .WithId(contato.Id)
                                .WithNome(empty)
                                .Build();

            //Act
            var httpResponseMessage = _httpClient.PutAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Update_Invalid_NotExists()
        {
            //Arrange
            Contato contato = CreateContatoEntity();

            var invalidId = 999;

            var command = new UpdateContatoCommandBuilder()
                                .Default()
                                .WithId(invalidId)                                
                                .Build();

            //Act
            var httpResponseMessage = _httpClient.PutAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Test]
        public void Delete_Valid()
        {
            //Arrange
            Contato contato = CreateContatoEntity();

            var command = new ContatoDeleteCommand()
            {
                Id = contato.Id,
            };

            //Act
            var httpResponseMessage = _httpClient.DeleteAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

            var deletedContato = (_contatoRepository.GetAllAsync().Result).SingleOrDefault(c => c.Id == contato.Id);
            deletedContato.Should().BeNull();
        }


        [Test]
        public void Delete_Invalid_Empty()
        {
            //Arrange
            var command = new ContatoDeleteCommand()
            {
            };

            //Act
            var httpResponseMessage = _httpClient.DeleteAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Delete_Invalid_NotExists()
        {
            //Arrange
            var invalidId = 999;

            var command = new ContatoDeleteCommand()
            {
                Id = invalidId
            };

            //Act
            var httpResponseMessage = _httpClient.DeleteAsJsonAsync(url, command).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public void GetAll()
        {
            //Arrange
            var regiao1 = new RegiaoBuilder().SaoPaulo().Build();
            var regiao2 = new RegiaoBuilder().RioDeJaneiro().Build();

            base.SeedData(regiao1);
            base.SeedData(regiao2);

            var contato1 = CreateContatoEntity(regiao1);
            var contato2 = CreateContatoEntity(regiao1);
            var contato3 = CreateContatoEntity(regiao2);

            var countAll = 3;

            //Act
            var httpResponseMessage = _httpClient.GetAsync(url).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var contatos = JsonConvert.DeserializeObject<IEnumerable<Contato>>(content);
            contatos.Should().HaveCount(countAll);
        }


        [Test]
        public void GetByRegiaoId()
        {
            //Arrange
            var regiao1 = new RegiaoBuilder().SaoPaulo().Build();
            var regiao2 = new RegiaoBuilder().RioDeJaneiro().Build();

            base.SeedData(regiao1);
            base.SeedData(regiao2);

            var contato1 = CreateContatoEntity(regiao1);
            var contato2 = CreateContatoEntity(regiao1);
            var contato3 = CreateContatoEntity(regiao2);

            var idRegiao1 = regiao1.Id;
            var countRegiao1 = 2;

            var urlListar = $"{url}/listar-por-ddd/{idRegiao1}";

            //Act
            var httpResponseMessage = _httpClient.GetAsync(urlListar).Result;

            //Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var contatos = JsonConvert.DeserializeObject<IEnumerable<ContatoQueryResult>>(content);
            contatos.Should().HaveCount(countRegiao1);
        }


        private Contato CreateContatoEntity(Regiao regiao = null)
        {
            if (regiao == null)
            {
                regiao = new RegiaoBuilder().SaoPaulo().Build();
                base.SeedData(regiao);
            }

            var contato = new ContatoBuilder()
                                .Default()            
                                .WithRegiaoId(regiao.Id)
                                .Build();

            _contatoRepository.Insert(contato);

            return contato;            
        }
    }
}
