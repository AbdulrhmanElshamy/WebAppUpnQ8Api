//using MailKit;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebAppUpnQ8Api.Configuration;
using WebAppUpnQ8Api.Models;
using WebAppUpnQ8Api.ViewModels;


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using WebAppUpnQ8Api.Repository;
using WebAppUpnQ8Api.RepositoryModels;
using Microsoft.Extensions.Configuration;
using Google;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using WebAppUpnQ8Api.Services.AccountServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings:ConnectionString").Value;
builder.Services.AddDbContext<WebAppUpnQ8ApiDBContext>(a => a.UseSqlServer(connectionStrings));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<WebAppUpnQ8ApiDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<PasswordHasher<ApplicationUser>>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddHttpContextAccessor();
var googleAuthSection = builder.Configuration.GetSection("Authentication:Google");
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var key = Encoding.ASCII.GetBytes(secretKey);


builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(option =>
    {
        option.RequireHttpsMetadata = false;
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
        option.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                var claims = claimsIdentity.Claims.ToList();
                Console.WriteLine("Claims:");
                foreach (var claim in claims)
                {
                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                }
                return Task.CompletedTask;
            }
        };
    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = googleAuthSection["ClientId"]; // Load from config
        googleOptions.ClientSecret = googleAuthSection["ClientSecret"]; // Load from config
        googleOptions.CallbackPath = "/signin-google"; // Default callback path
    })
    .AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseRouting();
//app.UseStaticFiles();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
//app.MapIdentityApi<ApplicationUser>();
app.MapControllers();

app.Run();
