using AppCursosUI.Gateways.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<IManejadorIdentidad, ManejadorIdentidadRESTProvider>();
builder.Services.AddHttpClient("ServicioIdentidad", client => {
    var servicioIdentidad = builder.Configuration.GetSection("Servicios")["servicioIdentidad"];
    client.BaseAddress = new Uri(servicioIdentidad);
    client.DefaultRequestHeaders.Add("accept", "application/json");    
});

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AplicacionCursos.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
