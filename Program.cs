using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(p =>
    p.AddPolicy("all", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin())
);

var app = builder.Build();

// Swagger siempre activado
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty; // Para ver swagger directo en /
});

// Middlewares
app.UseCors("all");
app.MapControllers();

// No usar app.Urls.Add() en Render

app.Run();
