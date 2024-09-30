using Infra.Data.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using Xunit;

namespace WebApi.Tests.Controllers
{
    public abstract class ControllerBaseTest : IClassFixture<WebApplicationFactory<Program>>, IAsyncLifetime
    {
        protected readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly MsSqlContainer _msSqlContainer;

        public ControllerBaseTest()
        {
            _msSqlContainer = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
                .WithPassword("Strong_password_123!")
                .Build();


            var _webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                    services.Remove(descriptor);
                    services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseSqlServer(_msSqlContainer.GetConnectionString());
                        });
                });
            });

            _serviceProvider = _webApplicationFactory.Services;
            _httpClient = _webApplicationFactory.CreateClient();
        }

        public ApplicationDbContext GetDbContext()
        {
            return _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected void StartDatabase()
        {
            var dbContext = GetDbContext();
            dbContext.Database.Migrate();
        }

        protected virtual void SeedData(params object[] data)
        {
            var dbContext = GetDbContext();
            dbContext.AddRange(data);
            dbContext.SaveChanges();
        }

        protected void ResetDatabase()
        {
            var dbContext = GetDbContext();
            dbContext.Database.ExecuteSqlRaw("DELETE CONTATO");
            dbContext.Database.ExecuteSqlRaw("DELETE REGIAO");
        }

        public async Task InitializeAsync()
        {
            await _msSqlContainer.StartAsync();
            //StartDatabase();
        }

        public async Task DisposeAsync()
        {
            await _msSqlContainer.StopAsync();
            //ResetDatabase();
        }
    }
}
