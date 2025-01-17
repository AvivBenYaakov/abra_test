using Microsoft.Extensions.Options;
using MongoDB.Driver;
using server.Models;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<PetsStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(PetsStoreDatabaseSettings)));

builder.Services.AddSingleton<IPetsStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PetsStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("PetsStoreDatabaseSettings.ConnectionString")));

builder.Services.AddScoped<IPetService, PetService>();


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
