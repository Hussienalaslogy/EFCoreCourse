using EF_CORE_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// === Logging ===
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);

// === Config the SmarterASP Database Connection String ===
builder.Services.AddDbContext<EF_CORE_API.Models2.SmarterASPContext2>(options =>
    options.UseSqlServer(Credintials.connectionString2));

// === Config the SmarterASP Database Connection String ===
builder.Services.AddDbContext<SmarterASPContext>(options =>
    options.UseSqlServer(Credintials.connectionString));


// === Add services to the container ===
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// === Configure the HTTP request pipeline ===
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
