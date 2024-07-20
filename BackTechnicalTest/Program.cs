using BackTechnicalTest.Domain.IRepositories;
using BackTechnicalTest.Infrastructure;
using BackTechnicalTest.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors( options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());
    });

builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowWebApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
