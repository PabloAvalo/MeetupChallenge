using Meetup.Dto.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meetup.Api.ClimaHelper
{
    public static class ClimaHelper
    {
        private const string KEY = "d5f0461e8cmshdceed573998b3dfp1b7b16jsn1210dbc9606b";
        private const string HOST = "community-open-weather-map.p.rapidapi.com";
        private const string BASE_URL = "https://community-open-weather-map.p.rapidapi.com/forecast/";


        public static async Task<List<ClimaDto>> GetClimaAsync(string ubicacion) {

            string url = BASE_URL + GetParametros(ubicacion);

            HttpRequestMessage httpRequest = new HttpRequestMessage();

            httpRequest.Headers.Add("x-rapidapi-host", HOST);
            httpRequest.Headers.Add("x-rapidapi-key", KEY);
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            List<ClimaDto> climas = new List<ClimaDto>();

            ClimaDto clima = new ClimaDto();

            using (HttpResponseMessage response = await new HttpClient().SendAsync(httpRequest)) {

                if (!response.IsSuccessStatusCode) {

                    return null;
                }

                string content = await  response.Content.ReadAsStringAsync();

                dynamic climaJson = JsonConvert.DeserializeObject(content);       

                foreach (var item in climaJson.list)
                {
                    string dt = item["dt"];

                    clima = new ClimaDto();

                    clima.ClimaPrincipal = (string) item["weather"][0]["main"];
            
                    clima.Descripcion = (string )item["weather"][0]["description"];
         
                    clima.Humedad = (string) item["humidity"];
                    clima.Mañana  = (string) item["temp"]["day"];
                    clima.Noche   = (string) item["temp"]["night"];
                    clima.Tarde   = (string) item["temp"]["eve"];
                    clima.TempMax = (string) item["temp"]["max"];
                    clima.TempMin = (string) item["temp"]["min"];

                    clima.Fecha = GetFormattedDate(dt);

                    climas.Add(clima);

                }
                                               
            }
                       
            return climas;

        
        }

        public static async Task<ClimaDto> GetClimaPorFecha(string ubicacion, DateTime dt) {

            var climas = await GetClimaAsync(ubicacion);
            
            ClimaDto climaDelEvento =  climas.Where(c => c.Fecha.Date == dt.Date).FirstOrDefault();

            return climaDelEvento;
        
        }

        public static async Task<double> GetTemperaturaDelEvento(string ubicacion, DateTime dt)
        {

            var clima = await GetClimaPorFecha(ubicacion,dt);

            if (clima == null) return double.MinValue;

            if (dt.Hour >= 6 && dt.Hour <= 12)
                return double.Parse(clima.Mañana);
            if (dt.Hour > 12 && dt.Hour <= 19)
                return double.Parse(clima.Tarde);

            return double.Parse(clima.Noche);


        }


        private static string GetParametros(string ubicacion) {

            string ubicacionSinEspacios = ubicacion.Trim().Replace(" ","%20");
            int cantidadDias = 5;
            return $"daily?q={ubicacionSinEspacios}&cnt={cantidadDias}&units=metric&lang=Spanish%20-%20es";          

        }

        private static DateTime GetFormattedDate(string date)
        {
            double unixTimeStamp = double.Parse(date);
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        
        }


    }
}
