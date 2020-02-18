using BussinesLogic.APIManager;
using IdentityModel.Client;
using Meetup.BussinesLogic.APIManager;
using Meetup.Dto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BussinesLogic.Controllers
{
    public class MeetupController : IMeetupController
    {

        //private const string baseUrl = "http://localhost:5001/api/Eventos";
        private  string baseUrl = APIHelper.MeetupUrl + "/Eventos";
        //private  string baseUrl= "https://meetupapi.azurewebsites.net/api/Eventos";
        public async Task<string> ObtenerIdentity()
        {
            //esto lo hace en todos los metodos, ver de refactorerlo.
            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            Console.WriteLine(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://meetup-identity.azurewebsites.net/");

            Console.WriteLine(response);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();

                return content;

            }


        }
        public async Task<EventoDto> CrearMeetUpAsync(EventoNuevoDto eventoNuevoDto)
        {
     
            EventoDto eventoNuevo = new EventoDto();

            TokenResponse tokenResponse = await IdentityController.GetToken();
            var apiClient = APIHelper.GetApiClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync(baseUrl, eventoNuevoDto))
            {

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string content = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(content, eventoNuevo);

            }

            return eventoNuevo;

        }
        public async Task EliminarMeetUp(int eventoId)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            using (HttpResponseMessage response = await apiClient.DeleteAsync(baseUrl + $"/{eventoId}"))
            {

                if (!response.IsSuccessStatusCode)
                {

                    throw new Exception(response.ReasonPhrase);

                }

            }

        }
        public async Task<double> ObtenerCantidadDeBirras(int eventoId)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            int cantidadBirraas = 0;

            using (HttpResponseMessage response = await apiClient.GetAsync(baseUrl + $"/{eventoId}/cantidadDeBirras"))
            {

                if (!response.IsSuccessStatusCode)
                {

                    return -1;

                }

                var birras = response.Content.ReadAsStringAsync();

                cantidadBirraas = 1;


            }

            return cantidadBirraas;
        }
        public async Task<ClimaDto> ObtenerClimarDeEvento(int eventoId) {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            ClimaDto clima = new ClimaDto();

            using (HttpResponseMessage response = await apiClient.GetAsync(baseUrl + $"/{eventoId}/Clima"))
            {

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(content, clima);


            }

            return clima;
        }
        public async Task<EventoDto> UpdateMeetUp(int eventoId, EventoPutDto eventoPut)
        {


            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            EventoDto eventoUpdated = new EventoDto();

            using (HttpResponseMessage response = await apiClient.PutAsJsonAsync(baseUrl + $"/{eventoId}", eventoPut))
            {

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string content = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(content, eventoUpdated);

            }

            return eventoUpdated;


        }
        public async Task<EventoDto> ObtenerMeetup(int eventoId)
        {
            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            Console.WriteLine(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync(baseUrl + $"/{eventoId}");
            EventoDto evento = new EventoDto();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                JsonConvert.PopulateObject(content, evento);

            }

            return evento;
        }
        public async Task<IEnumerable<EventoDto>> ObtenerOrganizadorMeetups(int organizadorId)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            List<EventoDto> eventos = new List<EventoDto>();

            var response = await apiClient.GetAsync(baseUrl + $"/Organizador/{organizadorId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                JsonConvert.PopulateObject(content, eventos);

            }

            return eventos;
        }

        public async Task<IEnumerable<EventoDto>> ObtenerProximosEventos()
        {
            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            List<EventoDto> eventos = new List<EventoDto>();

            var response = await apiClient.GetAsync(baseUrl + $"/Proximos");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                JsonConvert.PopulateObject(content, eventos);

            }

            return eventos;
        }

        public async Task<IEnumerable<EventoDto>> ObtenerEventosPorUsuario(int usuarioId)
        {
            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);
            

            List<EventoDto> eventos = new List<EventoDto>();

            string url = baseUrl + $"/usuario/{usuarioId}";
            try
            {
                var response = await apiClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JsonConvert.PopulateObject(content, eventos);

                }
            }

            catch (Exception e) {
                return null;
            }
         

            return eventos;
        }


        public async Task<List<EventoDto>> GetEventos() {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            List<EventoDto> eventos = new List<EventoDto>();

            var response = await apiClient.GetAsync(baseUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                JsonConvert.PopulateObject(content, eventos);

            }

            return eventos;

        }


        



    }
}
