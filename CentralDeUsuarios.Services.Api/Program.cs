using CentralDeUsuarios.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Obter a string de conex�o do MongoDB a partir da vari�vel de ambiente
var mongoConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");

// Configurar o MongoDB como singleton (inje��o de depend�ncia)
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoConnectionString));


// Opcional: se quiser injetar o banco j� selecionado
builder.Services.AddSingleton(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
return client.GetDatabase("ControleDeUsuariosTest");
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o contexto do banco de dados e carrega a string de conex�o do appsettings.json
//builder.Services.AddDbContext<SqlServerContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
//);

// Obt�m a connection string da vari�vel de ambiente
var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION")
                       ?? builder.Configuration.GetConnectionString("SqlServer");



builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
