using api_with_csharp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

 string conn = "Data Source=WIN-QQ6C7V0O4HI\\SQLEXPRESS;Initial Catalog=Kotlin;Integrated Security=True;Multiple Active Result Sets=True;Trust Server Certificate=True";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(opt => opt.UseSqlServer(conn,options => options.EnableRetryOnFailure()));
builder.Services.AddDbContext<UserContext>(opt=> opt.UseSqlServer(conn,options => options.EnableRetryOnFailure()));

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
