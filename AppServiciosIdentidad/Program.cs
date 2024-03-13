using AppServiciosIdentidad.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/validarUsuario", (PeticionInicioSesion peticion) =>
{    
    var respuesta = new RespuestaValidacionUsuario() { correcto=true};
    respuesta.usuario = new Usuario() { 
        correoElectronico=peticion.correoElectronico, 
        nombreCompleto="Usuario", 
        puesto="Puesto"};
    return respuesta;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
