using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SocialMedia_Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args);
//checking for Token
builder.AddAppAuthentication();
//configure development file
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy1", builder =>
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod());

});
var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.UseCors("policy1");
//an async method
app.UseOcelot().GetAwaiter().GetResult();
app.Run();
