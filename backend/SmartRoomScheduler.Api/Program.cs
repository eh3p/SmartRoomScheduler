using Microsoft.EntityFrameworkCore;
using SmartRoomScheduler.Api.Data;
using SmartRoomScheduler.Api.Services;
using SmartRoomScheduler.Api.Models; // ✅ أضفت الـ namespace بتاع الـ Models
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<JwtService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", p => p
        .WithOrigins(builder.Configuration["FrontendUrl"] ?? "http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT
var jwtKey = builder.Configuration["Jwt:Key"] ?? "dev_fallback_key_change_me";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "SmartRoomScheduler";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "SmartRoomSchedulerUsers";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience
        };
    });

var app = builder.Build();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Apply migrations automatically on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    // Seed basic data if empty
    if (!db.Rooms.Any())
    {
        db.Rooms.AddRange(
            new Room { Name = "Room 101", Capacity = 30, Equipment = "Projector,Whiteboard", IsActive = true },
            new Room { Name = "Room 102", Capacity = 25, Equipment = "TV,HDMI", IsActive = true },
            new Room { Name = "Lab A", Capacity = 20, Equipment = "PCs,Projector", IsActive = true }
        );
        db.SaveChanges();
    }
}

app.Run();
