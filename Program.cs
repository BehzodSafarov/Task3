using DotNet.Repositories;
using DotNet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Myproject",
                      policy  =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
 options.UseSqlite("Data Source = Data.db;");
 options.UseLazyLoadingProxies();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IGamerRepository, GamerRepository>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IGamerService, GamerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Myproject");

app.UseAuthorization();

app.MapControllers();

app.Run();
