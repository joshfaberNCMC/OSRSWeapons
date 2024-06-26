using Microsoft.EntityFrameworkCore;
using OSRSWeapons.Configurations;
using OSRSWeapons.Repositories;
using OSRSWeapons.Services;

var builder = WebApplication.CreateBuilder(args);

// Adds our Controllers to our container and configures our [ApiController] behavior.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// IConfiguration
builder.Services.AddSingleton(builder.Configuration);

// Repositories
builder.Services.AddScoped<OSRSWeaponsDbContext>();
builder.Services.AddScoped<IWeaponsRepository, WeaponsRepositoryImpl>();

// Services
builder.Services.AddScoped<WeaponsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(_ => {});

app.Run();
