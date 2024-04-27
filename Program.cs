using OSRSWeapons.Configurations;
using OSRSWeapons.Repositories;
using OSRSWeapons.Services;

var builder = WebApplication.CreateBuilder(args);

// A dd services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

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
