using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Acessa arquivo de configuração
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Adiciona DbContext via injeção de dependência
builder.Services.AddDbContext(configuration);

// Adiciona classes via injeção de dependência
builder.Services.Register();

// Injeção de dependência das classes de Repository
//builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
//builder.Services.AddScoped<IDddRepository, DddRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Make the implicit Program class public so test projects can access it
public partial class Program { }