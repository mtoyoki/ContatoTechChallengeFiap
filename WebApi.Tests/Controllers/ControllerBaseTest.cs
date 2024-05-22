using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WebApi.Tests
{
    public abstract class ControllerBaseTest
    {
        protected readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;
        private const string connectionString = "Data Source =.;database=DB_CONTATO_TEST;Trusted_Connection=True;";

        public ControllerBaseTest()
        {
            var _webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                    services.Remove(descriptor);
                    services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });
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
            dbContext.Database.ExecuteSqlRaw("delete contato");
            dbContext.Database.ExecuteSqlRaw("delete regiao");
        }
    }
}
