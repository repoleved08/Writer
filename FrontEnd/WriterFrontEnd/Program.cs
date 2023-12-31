using WriterFrontEnd;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Blazorise;
//using Blazorise.Bulma;
//using Blazorise.Icons.FontAwesome;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using WriterFrontEnd.Services.AuthProvider;
using WriterFrontEnd.Services.Auth;
using WriterFrontEnd.Services.PostServ;
using WriterFrontEnd.Services.Comments;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// start
//builder.Services
//    .AddBlazorise(options =>
//    {
//        options.Immediate = true;
//    })
//    .AddBulmaProviders()
//    .AddFontAwesomeIcons();
// end
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Registerservices
builder.Services.AddScoped<IPostsInterface, PostsService>();

// Auth
builder.Services.AddScoped<IAuthentInterface, AuthentService>();
builder.Services.AddScoped<ICommentInterface, CommentService>();

// localstorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvideService>();



await builder.Build().RunAsync();
