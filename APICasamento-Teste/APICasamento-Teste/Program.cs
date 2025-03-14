using APICasamento.Services.Implementation;
using APICasamento.Services.Interfaces;
using APICasamento_Teste.Services.Implementation;
using APICasamento_Teste.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração do contexto SQLite
builder.Services.AddDbContext<SQLiteServerContext>(options =>
    options.UseSqlite("Data Source=db_casamentomn.db"));

// Registro do serviço IPresenteService e sua implementação
builder.Services.AddScoped<IPresenteService, PresenteService>();
builder.Services.AddScoped<IFormularioService, FormularioService>();

// Adiciona suporte a controladores
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://casamento-mn.vercel.app", "https://matheusenadyr.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuração do pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ? CHAMAR O CORS ANTES DE Authorization e MapControllers
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
