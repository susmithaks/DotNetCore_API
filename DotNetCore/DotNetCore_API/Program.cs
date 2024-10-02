using DotNetCore_API.Data;
using DotNetCore_API.Mappings;
using DotNetCore_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DotNetCoreDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DotNetCoreConnectionString")));

builder.Services.AddScoped<IRegionRepository, SQLRegionReository>();
builder.Services.AddScoped<IWalkRepository, SqlWalksRepository>();


builder.Services.AddAutoMapper(typeof(AutomapperProfiles));


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
