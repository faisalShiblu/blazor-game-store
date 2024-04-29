using FrontEnd.Clients;
using FrontEnd.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSingleton<GamesClient>();
builder.Services.AddSingleton<GenresClient>();

//var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
//    throw new Exception("GameStoreApiUrl is not set");

//builder.Services.AddHttpClient<GamesClient>(
//    client => client.BaseAddress = new Uri(gameStoreApiUrl));

//builder.Services.AddHttpClient<GenresClient>(
//    client => client.BaseAddress = new Uri(gameStoreApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
