using AuthService.Data;
using AuthService.Extensions;
using AuthService.Services;
using AuthService.Services.IServices;
using AuthService.Utitlity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MessageBusLib;
using SenderBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

//Register Services
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();  
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IMessageBus, MessageBus>();
//mine
builder.Services.AddScoped<ISenderBus, MessageBusService>();

//cors
builder.Services.AddCors(options => options.AddPolicy("policy0", build =>
{
    //build.WithOrigins("https://localhost:7257");
    build.AllowAnyOrigin();
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}));
//Register IdentityFramework
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

//Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//configure JWtOptions 
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddHttpClient("Posts", c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrl:PostsApi"]));

//custom builder services
builder.AddAppAuthentication();
builder.AddSwaggenGenExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMigration();
app.UseCors("policy0");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
