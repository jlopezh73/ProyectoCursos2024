using AppCursosUIBlazor.DTOs;
using AppCursosUIBlazor.Gateways.Interfaces;

namespace AppCursosUIBlazor.Gateways.Providers;

public class ManejadorIdentidadRESTProvider : IManejadorIdentidad
{
    RespuestaValidacionUsuario x;
    HttpClient clienteServicioIdentidad;
    public ManejadorIdentidadRESTProvider(IHttpClientFactory httpClientFactory) {
        clienteServicioIdentidad = httpClientFactory.CreateClient("ServicioIdentidad");
    }
    public RespuestaValidacionUsuario ValidarUsuario(PeticionInicioSesion peticionInicioSesion)
    {
        try {
            var resultado = clienteServicioIdentidad.PostAsJsonAsync<PeticionInicioSesion>("/validarUsuario", peticionInicioSesion).Result;
            resultado.EnsureSuccessStatusCode();
            var respuesta = resultado.Content.ReadFromJsonAsync<RespuestaValidacionUsuario>().Result;    
            return respuesta;
        } catch (Exception e) {
            return new RespuestaValidacionUsuario() { correcto=false};
        }

    }
}