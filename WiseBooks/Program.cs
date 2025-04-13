using WiseBooks.Components;
using WiseBooks.Services;
using MudBlazor.Services; // Add this line

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddMudServices(); // Now this will work
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<StockDataService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();