using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p =>
    p.AddPolicy("all", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin())
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("all");
app.MapControllers();

// Render port
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();

