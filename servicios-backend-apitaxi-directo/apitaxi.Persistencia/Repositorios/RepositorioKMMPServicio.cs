using ApiTaxi.Aplicacion.CasosDeUso.Externo.KMMP.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace ApiTaxi.Persistencia.Repositorios
{
    public class RepositorioKMMPServicio : IRepositorioKMMPServicio
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public RepositorioKMMPServicio(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<KmmpEstadosResponseDto> ObtenerEstadosPush()
        {
            var url = _config["KmmpApi:BaseUrl"] + _config["KmmpApi:push"];


            //En caso de haber un request, se debe serializar
            //var json = JsonSerializer.Serialize(request);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            //var response = await _httpClient.PostAsync(url, content);
            //response.EnsureSuccessStatusCode();
            //var body = await response.Content.ReadAsStringAsync();
            //return JsonSerializer.Deserialize<KmmpEstadosResponseDto>(body)!;

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KmmpEstadosResponseDto>(body)!;

        }
    }
}
