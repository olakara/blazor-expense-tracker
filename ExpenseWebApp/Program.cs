using ExpenseWebApp.Components;
using ExpenseWebApp.DTO;
using ExpenseWebApp.Infrastructure;
using ExpenseWebApp.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IExpenditureService, ExpenditureService>();

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