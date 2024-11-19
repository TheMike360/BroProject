using Microsoft.OpenApi.Models;
using TelegramBotAPI.Data;
using TelegramBotAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TgBotSwagger", Version = "v1" });
});

builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddScoped<BotService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
