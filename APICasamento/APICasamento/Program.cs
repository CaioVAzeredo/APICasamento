using APICasamento.Data.Context;
using APICasamento.Services.Interfaces;
using APICasamento.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

// Configurando o banco de dados MySQL
builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 31)) // Altere para sua versão do MySQL
    )
);

// Registrando o serviço IPresenteService
builder.Services.AddScoped<IPresenteService, PresenteService>();

// Adicionando controllers
builder.Services.AddControllers();

// Configurando o Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurando o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
