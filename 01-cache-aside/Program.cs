using Microsoft.EntityFrameworkCore;

using SingletonDP.Models;
using SingletonDP.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("PolicyConnection")));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "SingletonDP_";
});
builder.Services.AddSingleton<ILoggerServices, LoggerService>();
builder.Services.AddSingleton<ISingletonTracker, LifeTimeTracker>();
builder.Services.AddScoped<IScopedTracker, LifeTimeTracker>();
builder.Services.AddTransient<ITransientTracker, LifeTimeTracker>();

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
