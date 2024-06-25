using Microsoft.AspNetCore.Identity;
using UrlShortenAPI.Models;
using UrlShortenAPI.Service;
using Microsoft.EntityFrameworkCore;
using UrlShortenAPI.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UrlShortenIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'UrlShortenIdentityContextConnection' not found.");

builder.Services.AddDbContext<UrlShortenContext>(options => options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UrlShortenContext>();

// Add controllers
builder.Services.AddControllers();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
        builder.WithOrigins("http://localhost:5173", "https://localhost:5173")
             .AllowAnyHeader()
             .AllowAnyMethod());
});

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Identity and authorization
builder.Services.AddAuthorization();

// Add transient service
builder.Services.AddTransient<IShortService, ShortService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();