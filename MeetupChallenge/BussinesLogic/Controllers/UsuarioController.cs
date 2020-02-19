using BussinesLogic.APIManager;
using BussinesLogic.Controllers;
using IdentityModel.Client;
using Meetup.BussinesLogic.APIManager;
using Meetup.Dto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BussinesLogic.Controllers
{
    public class UsuarioController : IUsuarioController

    {
        private const string Topico = "Topic"; //deberia ser un enum

        private  string baseUrl = APIHelper.MeetupUrl;
        public async Task HacerCheckIn(int inscripcionId)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


            using (var response = await apiClient.PostAsync(baseUrl + $"/inscripcion/{inscripcionId}/CheckIn", null))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }


        public async Task AddTopicoFavorito(ConfiguracionNuevaDto configuracion)
        {

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);



            using (var response = await apiClient.PostAsJsonAsync("/Usuarios/preferencias", configuracion))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }



        }

        public async Task RegistrarInscripcion(InscripcionNuevaDto dto)
        {
            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

         
            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync("/inscripcion", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<UsuarioDto> Login(UsuarioLoginDto dto)
        {
          
            UsuarioDto loggedInUsuario = new UsuarioDto();

            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


            using (var response = await apiClient.PostAsJsonAsync("/Usuarios", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                string usu = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(usu, loggedInUsuario);


            }

            return loggedInUsuario;
        }

        public async Task SignUp(UsuarioNuevoDto usuario)
        {


            TokenResponse tokenResponse = await IdentityController.GetToken();

            var apiClient = APIHelper.GetApiClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);


            using (var response = await apiClient.PostAsJsonAsync($"/Usuarios", dto))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //obtenerNotificaciones (int userId); 



    }
}
