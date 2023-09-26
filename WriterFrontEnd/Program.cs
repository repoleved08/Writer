using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WriterFrontEnd;
using WriterFrontEnd.Services.Comments;
using WriterFrontEnd.Services.Posts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Registering localStaorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IPostInterface, PostService>();
builder.Services.AddScoped<ICommentInterface, CommentService>();
//builder.Services.AddScoped<IAuthInterface, AuthService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();



await builder.Build().RunAsync();
