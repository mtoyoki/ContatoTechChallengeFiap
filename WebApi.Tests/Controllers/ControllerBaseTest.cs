using FluentAssertions.Common;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebApi.Tests
{
    public abstract class ControllerBaseTest
    {
        protected readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;

        public ControllerBaseTest()
        {
            var _webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                // Acessa arquivo de configuração
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();                

                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                    services.Remove(descriptor);
                    services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("ConnectionStringTest")); });
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
    }
}
