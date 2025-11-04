using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Application;
using Persistance;
using Infrastructure;
using Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddApplicationLayer();
builder.Services.AddPersistanceLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer();


var app = builder.Build();
await using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    var seedDataProvider = services.GetRequiredService<SeedDataProvider>();
    await seedDataProvider.SeedFactorySensorDataAsync();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
