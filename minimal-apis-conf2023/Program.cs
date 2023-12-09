using AutoMapper;
using minimal_apis_conf2023.DataBase;
using minimal_apis_conf2023.Extensions;
using minimal_apis_conf2023.Models.Request;
using minimal_apis_conf2023.Repositories;
using minimal_apis_conf2023.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpoints();

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new DbConnectionFactory(config.GetValue<string>("ConnectionStrings:PokemonDb")));
builder.Services.AddTransient<IPokemonRepository,PokemonRepository>();
builder.Services.AddTransient<IPokemonService,PokemonService>();

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();
app.Run();