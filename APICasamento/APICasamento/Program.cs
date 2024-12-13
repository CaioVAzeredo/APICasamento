using APICasamento.Data.Context;
using APICasamento.Services.Interfaces;
using APICasamento.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 31)) 
    )
);

// Registrando o serviço IPresenteService
builder.Services.AddScoped<IPresenteService, PresenteService>();
builder.Services.AddScoped<IInformacoesService, InformacoesService>();
builder.Services.AddScoped<IFormularioService, FormularioService>();

// Adicionando controllers
builder.Services.AddControllers();

// Configurando o Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
