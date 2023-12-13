using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Repo;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//client configuration 

builder.Services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Database
builder.Services.AddDbContext<MovieDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("connection"))); // design pattern that connects to the database
builder.Services.AddScoped<IGeneric<Movies>, GenericRepocs<Movies>>();
builder.Services.AddScoped<IGeneric<Actor>, GenericRepocs<Actor>>();
builder.Services.AddScoped<IGeneric<Award>,GenericRepocs<Award>>();
builder.Services.AddScoped<IGeneric<Booking>, GenericRepocs<Booking>>();
builder.Services.AddScoped<IGeneric<Country>, GenericRepocs<Country>>();
builder.Services.AddScoped<IGeneric<Genre>, GenericRepocs<Genre>>();
builder.Services.AddScoped<IGeneric<Language>, GenericRepocs<Language>>();
builder.Services.AddScoped<IGeneric<Review>, GenericRepocs<Review>>();
builder.Services.AddScoped<IGeneric<User>, GenericRepocs<User>>();
builder.Services.AddScoped<IGeneric<MovieActor>, GenericRepocs<MovieActor>>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
