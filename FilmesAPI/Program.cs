using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Conex�o com a string do AppSettings sendo envocada
var conn = (builder.Configuration
    .GetConnectionString("FilmeConnection"));

builder.Services.AddDbContext<FilmeContext>(opts => opts.UseMySql(conn, ServerVersion.AutoDetect(conn)));

//Adicionando o AutoMapper respons�vel pelo mapeamento autom�tico:
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
