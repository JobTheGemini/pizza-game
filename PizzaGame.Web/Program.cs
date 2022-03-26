using PizzaGame.Core;
using PizzaGame.Core.Interfaces;
using PizzaGame.Web;

const int minPizzas = 11;
const int maxPizzas = 100;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<IGame>(_ => new Game(minPizzas, maxPizzas));
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000")
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true);
    });
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapHub<GameHub>("/game");
app.UseCors("AllowOrigin");
app.MapFallbackToFile("index.html");

app.Run();