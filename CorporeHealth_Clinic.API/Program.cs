using CorporeHealth_Clinic.API.Data;
using CorporeHealth_Clinic.API.Domains.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoctorDbContext>(
    options => options
    .UseLazyLoadingProxies()
    .UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

//Injetar dependência do Identity Framework para uso avançado do entity. 
builder.Services.AddIdentity<Doctor, IdentityRole>().AddEntityFrameworkStores<DoctorDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
