using HomeAutomation.Application.Mappers;
using HomeAutomation.infrastructure.Data;
using HomeAutomation.infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddRepositories();
builder.Services.AddServices();

// mapper
builder.Services.AddAutoMapperProfiles();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<HomeAutomation.API.Middlewares.ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
