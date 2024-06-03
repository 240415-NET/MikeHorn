using Microsoft.EntityFrameworkCore;
using Project11EF.API.Services;
using Project11EF.API.Models;
using Project11EF.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This adds our UserService, that our UserController then asks for
builder.Services.AddScoped<IUserService, UserService>();
// This adds our UserStorageEFRepo (data-access layer), that our UserService asks for.
builder.Services.AddScoped<IUserStorageEF, UserStorageEF>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connections
string connectionString = File.ReadAllText(@"C:\Users\A219146\OneDrive - Government Employees Insurance Company\NET Bootcamp\SQL\Project11EF\Project11EFConnection.txt");
builder.Services.AddDbContext<Project11EFContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
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
