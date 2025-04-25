using ExpenseWebApp.Components;
using ExpenseWebApp.DTO;
using ExpenseWebApp.Infrastructure;
using ExpenseWebApp.Interfaces;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IExpenditureService, ExpenditureService>();
builder.Services.AddScoped<IExpenditureCache, ExpenditureCacheService>();

var expenseApiOptions = builder.Configuration.GetSection("ExpenseApiOptions").Get<ExpenseApiOptions>();
if (expenseApiOptions != null)
{
    builder.Services.AddRefitClient<IExpenditureAPI>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(expenseApiOptions.BaseUrl))
        .AddStandardResilienceHandler();
}
else
{
    throw new InvalidOperationException("ExpenseApiOptions section is missing in the configuration.");
}

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddHybridCache();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

