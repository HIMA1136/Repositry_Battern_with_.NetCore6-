using Microsoft.EntityFrameworkCore;
using Repositry_Pattern.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Repositry_Pattern.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using Repositry_Pattern.core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<Applicationdbcontext>(options =>
             options.UseSqlServer(
                 builder.Configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(Applicationdbcontext).Assembly.FullName)));
builder.Services.AddTransient(typeof(Ibaserepositry<>), typeof(baserepositry<>));
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
