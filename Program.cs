using Microsoft.EntityFrameworkCore;
using TestBackEnd.Data;
using TestBackEnd.Data.Repositories;
using TestBackEnd.Repositories;
using TestBackEnd.Services;
using TestBackEnd.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Репозитории
builder.Services.AddScoped<IPersonRepository, PersonRepository>();


// Сервисы
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddControllers();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

