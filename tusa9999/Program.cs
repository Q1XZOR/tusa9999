using Microsoft.EntityFrameworkCore;
using Party.WebApi.Repositories;
using Party.WebApi.Context;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddDbContext<GuestDbContext>(option =>
{
    option.UseInMemoryDatabase("guest-db");
});

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();