using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AppCursosUIBlazor.Data;
using AppCursosUIBlazor.Gateways.Interfaces;
using AppCursosUIBlazor.Gateways.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IManejadorIdentidad, ManejadorIdentidadRESTProvider>();
builder.Services.AddHttpClient("ServicioIdentidad", client => {
    var servicioIdentidad = builder.Configuration.GetSection("Servicios")["servicioIdentidad"];
    client.BaseAddress = new Uri(servicioIdentidad);
    client.DefaultRequestHeaders.Add("accept", "application/json");    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
