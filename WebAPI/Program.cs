using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<MovieDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("connection"))); // design pattern that connects to the database
builder.Services.AddScoped<IGeneric<Movies>, GenericRepocs<Movies>>();

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
