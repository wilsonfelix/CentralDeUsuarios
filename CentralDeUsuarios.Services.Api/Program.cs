using CentralDeUsuarios.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o contexto do banco de dados e carrega a string de conexão do appsettings.json
//builder.Services.AddDbContext<SqlServerContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
//);

// Obtém a connection string da variável de ambiente
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
